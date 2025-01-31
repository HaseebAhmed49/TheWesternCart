import { Component, OnInit } from '@angular/core';
import { OrdersHistoryService } from '../orders-history.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { OrderHistory } from '../../shared/models/order-history';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { SharedModule } from '../../shared/shared.module';

@Component({
  selector: 'app-orders-history',
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
    RouterModule
  ],
  templateUrl: './orders-history.component.html',
  styleUrls: ['./orders-history.component.sass']
})

export class OrdersHistoryComponent implements OnInit {
  orderHistories: OrderHistory[] = [];
  displayedColumns: string[] = ['order', 'date', 'total', 'status'];
  constructor(private ordersHistoryService: OrdersHistoryService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('userId');
    if (userId) {
      this.getOrderHistoriesForUser(userId);
    }
  }
  getOrderHistoriesForUser(userId: string) {
    this.ordersHistoryService.getOrderHistoriesForUser(userId).subscribe({
      next: orderHistories => this.orderHistories = orderHistories
    });
  }
}