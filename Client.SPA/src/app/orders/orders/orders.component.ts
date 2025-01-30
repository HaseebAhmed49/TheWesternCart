import {Component, OnInit} from '@angular/core';
import {OrdersService} from '../orders.service';
import { Order } from '../../shared/models/order';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-orders',
  imports: [
      CommonModule,
      MaterialModule,
      RouterModule
    ],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.sass'
})

export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  displayedColumns: string[] = ['order', 'date', 'total', 'status'];
  constructor(private orderService: OrdersService) {
  }
  ngOnInit(): void {
    this.getOrders();
  }
  getOrders() {
    this.orderService.getOrdersForUser().subscribe({
      next: orders => this.orders = orders
    })
  }
}
