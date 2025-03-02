import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderHistory } from '../shared/models/order-history';
import { environment } from '../../environments/environment';
import { Guid } from 'guid-typescript'

@Injectable({
  providedIn: 'root'
})

export class OrdersHistoryService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  getOrderHistoriesForUser(userId: string): Observable<OrderHistory[]> {
    return this.http.get<OrderHistory[]>(`${this.baseUrl}ordershistory/${userId}`);
  }
  getOrderHistoryById(id: string): Observable<OrderHistory> {
    return this.http.get<OrderHistory>(`${this.baseUrl}ordershistory/order/${id}`);
  }
}