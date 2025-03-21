import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';
import { environment } from '../../../environments/environment';
import { Rating } from '../models/rating';

@Injectable({
  providedIn: 'root'
})

export class RatingService {
  baseUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) {
  }
  
  addRating(rating: Rating): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}rating/${rating}`, {});
  }

  getAverageRating(clothingItemId: string): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}rating/clothing/${clothingItemId}/average`);
  }
  
  getUserRating(userId: string, clothingItemId: string): Observable<Rating | null> {
    return this.http.get<Rating | null>(`${this.baseUrl}rating/user-rating/${clothingItemId}`);
  }
}