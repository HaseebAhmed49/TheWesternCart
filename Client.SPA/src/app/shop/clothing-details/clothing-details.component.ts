import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';
import { take } from 'rxjs';
import { ClothingItem } from '../../shared/models/clothing-item';
import { AccountService } from '../../account/account.service';
import { User } from '../../shared/models/user';
import { RatingService } from '../../shared/rating/rating.service';
import { Rating } from '../../shared/models/rating';
import { BasketService } from '../../basket/basket.service';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { RatingComponent } from '../../shared/rating/rating.component';

@Component({
  selector: 'app-clothing-details',
  imports: [
    CommonModule,
    MaterialModule,
    RatingComponent
  ],
  templateUrl: './clothing-details.component.html',
  styleUrl: './clothing-details.component.sass'
})
export class ClothingDetailsComponent implements OnInit {
  product?: ClothingItem;
  quantity = 1;
  quantityInBasket = 0;
  user?: User;

  averageRating: number | undefined;
  userRating: number | undefined;
  
  constructor(private accountService: AccountService, private ratingService: RatingService, private shopService: ShopService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService, private basketService: BasketService) {
    this.bcService.set('@productDetails', ' ')
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => {
        if (user) this.user = user;
      }
    })
  }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) {
      this.shopService.getClothing(id).subscribe({
        next: product => {
          this.product = product;
          this.bcService.set('@productDetails', product.name);
          this.basketService.basketSource$.pipe(take(1)).subscribe({
            next: basket => {
              const item = basket?.items.find(x => x.id === id);
              if (item) {
                this.quantity = item.quantity;
                this.quantityInBasket = item.quantity;
              }
            }
          });
          this.loadRatings(id);
        },
        error: error => console.log(error)
      });
    }
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  updateBasket() {
    if (this.product) {
      if (this.quantity > this.quantityInBasket) {
        const itemsToAdd = this.quantity - this.quantityInBasket;
        this.quantityInBasket += itemsToAdd;
        this.basketService.addItemToBasket(this.product, itemsToAdd);
      } else {
        const itemsToRemove = this.quantityInBasket - this.quantity;
        this.quantityInBasket -= itemsToRemove;
        this.basketService.removeItemFromBasket(this.product.id, itemsToRemove);
      }
    }
  }

  get buttonText() {
    return this.quantityInBasket === 0 ? 'Add to basket' : 'Update basket';
  }

  loadRatings(clothingItemId: string) {
    this.ratingService.getAverageRating(clothingItemId).subscribe({
      next: averageRating => {
        this.averageRating = averageRating;
      },
      error: error => console.log(error)
    });

    if (this.user) {
      this.ratingService.getUserRating(this.user.id, clothingItemId).subscribe({
        next: userRating => {
          this.userRating = userRating ? userRating.score : undefined;
        },
        error: error => console.log(error)
      });
    }
  }

  onRating(rating: number) {
    if (this.product && this.user) {
      const newRating: Rating = {
        userId: this.user.id,
        username: this.user.username,
        clothingItemId: this.product.id,
        score: rating
      };
      
      this.ratingService.updateRating(newRating).subscribe({
        next: () => {
          console.log('Rating updated successfully');
          this.loadRatings(this.product!.id);
        },
        error: error => {
          console.log('Error updating rating:', error);
          this.ratingService.addRating(newRating).subscribe({
            next: () => {
              console.log('Rating added successfully');
              this.loadRatings(this.product!.id);
            },
            error: error => console.log('Error adding rating:', error)
          });
        }
      });
    }
  }
}