import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { ClothingItem } from '../../shared/models/clothing-item';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FavouritesService } from '../../favourites/favourites.service';
import { WishlistService } from '../../wishlist/wishlist.service';
import { SharedService } from '../../wishlist/shared.service';

@Component({
  selector: 'app-clothing-item',
  imports: [
    MaterialModule,
    CommonModule,
    RouterModule
  ],
  templateUrl: './clothing-item.component.html',
  styleUrl: './clothing-item.component.sass'
})
export class ClothingItemComponent implements OnInit {
  @Input() product?: ClothingItem;
 
  isFavorite: boolean = false;
  defaultWishlistId: string | null = null;

  constructor(
    private basketService: BasketService,
    private favoritesService: FavouritesService,
    private wishlistService: WishlistService,
    private sharedService: SharedService
  ) {}

  ngOnInit(): void {
    if (this.product) {
      this.favoritesService.isFavorite(this.product.id).subscribe({
        next: (isFav) => this.isFavorite = isFav,
        error: (error) => console.error(error)
      });
    }
    this.sharedService.defaultWishlistId$.subscribe({
      next: (id) => this.defaultWishlistId = id
    });
  } 

  addItemToBasket() {
    this.product && this.basketService.addItemToBasket(this.product);
  }

  toggleFavorite() {
    if (this.product) {
      if (this.isFavorite) {
        this.favoritesService.removeFavorite(this.product.id).subscribe({
          next: () => this.isFavorite = false,
          error: (error) => console.error(error)
        });
      } else {
        this.favoritesService.addFavorite(this.product.id).subscribe({
          next: () => this.isFavorite = true,
          error: (error) => console.error(error)
        });
      }
    }
  }

  addToWishlist() {
    if (this.product && this.defaultWishlistId) {
      this.wishlistService.addItemToWishlist(this.product.id, this.defaultWishlistId).subscribe({
        next: () => console.log('Item added to wishlist'),
        error: (error) => console.error(error)
      });
    }
  }
}