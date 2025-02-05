import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { ClothingItem } from '../../shared/models/clothing-item';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FavouritesService } from '../../favourites/favourites.service';

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

  constructor(private basketService: BasketService, private favoritesService: FavouritesService) { }
  
  ngOnInit(): void {
    if (this.product) {
      this.favoritesService.isFavorite(this.product.id).subscribe({
        next: (isFav) => this.isFavorite = isFav,
        error: (error) => console.error(error)
      });
    }
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
}