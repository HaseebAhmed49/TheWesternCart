import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../orders.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { Order } from '../../shared/models/order';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-detailed',
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule
  ],
  templateUrl: './order-detailed.component.html',
  styleUrl: './order-detailed.component.sass'
})

export class OrderDetailedComponent implements OnInit {
  order?: Order;
  displayedColumns: string[] = ['product', 'price', 'quantity', 'total'];
  constructor(private ordersService: OrdersService, private route: ActivatedRoute,
              private bcService: BreadcrumbService) {
    this.bcService.set('@OrderDetailed', ' ');
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    id && this.ordersService.getOrderDetailed(+id).subscribe({
      next: order => {
        this.order = order;
        this.bcService.set('@OrderDetailed', `Order# ${order.id} - ${order.status}`);
      }
    })
  }
}
