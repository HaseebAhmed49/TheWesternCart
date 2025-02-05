import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { FavoriteItemDto } from '../shared/models/favourite-item';
import { FavouritesService } from './favourites.service';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../shared/modules/material/material.module';

@Component({
  selector: 'app-favourites',
  imports: [
    CommonModule,
    MaterialModule
  ],
  templateUrl: './favourites.component.html',
  styleUrl: './favourites.component.sass'
})
export class FavouritesComponent implements OnInit {

  favoriteItems: FavoriteItemDto[] = [];

  constructor(private favoritesService: FavouritesService) { }

  ngOnInit(): void {
    this.loadFavorites();
  }

  loadFavorites() {
    this.favoritesService.getFavoritesByUserId().subscribe({
      next: (favorites) => {
        this.favoriteItems = favorites;
        this.favoriteItems.forEach(item => {
        });
      },
      error: (error) => console.error('Error loading favorites:', error)
    });
  }

  removeFavorite(clothingItemId: string) {
    console.log('Removing favorite with ID:', clothingItemId);
    this.favoritesService.removeFavorite(clothingItemId).subscribe({
      next: () => {
        this.favoriteItems = this.favoriteItems.filter(item => item.clothingItemDtoId !== clothingItemId);
      },
      error: (error) => console.error('Error removing favorite:', error)
    });
  }
}
