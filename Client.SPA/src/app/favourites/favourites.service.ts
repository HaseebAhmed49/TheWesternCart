import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';
import { FavoriteItemDto } from '../shared/models/favourite-item';

@Injectable({
  providedIn: 'root'
})
export class FavouritesService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addFavorite(clothingItemId: string): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}favourites/${clothingItemId}`, {});
  }

  removeFavorite(clothingItemId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}favourites/${clothingItemId}`);
  }

  getFavoritesByUserId(): Observable<FavoriteItemDto[]> {
    return this.http.get<FavoriteItemDto[]>(`${this.baseUrl}favourites/user`);
  }

  isFavorite(clothingItemId: string): Observable<boolean> {
    console.log("Testing isFavorite code");
    return this.http.get<boolean>(`${this.baseUrl}favourites/${clothingItemId}/isFavorite`);
  }}
