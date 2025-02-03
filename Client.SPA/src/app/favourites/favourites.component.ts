import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { FavoriteItem } from '../shared/models/favourite-item';
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
  favoriteItems: FavoriteItem[] = [];
  constructor(private favoritesService: FavouritesService) { }
  ngOnInit(): void {
    this.loadFavorites();
  }
  loadFavorites() {
    this.favoritesService.getFavoritesByUserId().subscribe({
      next: (favorites) => this.favoriteItems = favorites,
      error: (error) => console.error(error)
    });
  }
  removeFavorite(clothingItemId: string) {
    this.favoritesService.removeFavorite(clothingItemId).subscribe({
      next: () => this.favoriteItems = this.favoriteItems.filter(item => item.clothingItemId !== clothingItemId),
      error: (error) => console.error(error)
    });
  }
}
