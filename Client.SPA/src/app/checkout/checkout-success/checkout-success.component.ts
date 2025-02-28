import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { Order } from '../../shared/models/order';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { SharedModule } from '../../shared/shared.module';

@Component({
  selector: 'app-checkout-success',
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
    RouterModule
  ],
  templateUrl: './checkout-success.component.html',
  styleUrl: './checkout-success.component.sass'
})
export class CheckoutSuccessComponent {
  order?: Order;

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    this.order = navigation?.extras?.state as Order
  }
}
