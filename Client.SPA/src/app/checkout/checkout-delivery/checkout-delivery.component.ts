import { Component, Input, OnInit } from '@angular/core';
import { DeliveryMethod } from '../../shared/models/delivery-method';
import { CheckoutService } from '../checkout.service';
import { BasketService } from '../../basket/basket.service';
import { FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../shared/modules/material/material.module';

@Component({
  selector: 'app-checkout-delivery',
  imports: [
    CommonModule,
    MaterialModule
  ],
  templateUrl: './checkout-delivery.component.html',
  styleUrl: './checkout-delivery.component.sass'
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkoutForm?: FormGroup;
  deliveryMethods: DeliveryMethod[] = [];

  constructor(private checkoutService: CheckoutService, private basketService: BasketService) {
  }

  ngOnInit(): void {
    this.checkoutService.getDeliveryMethods().subscribe({
      next: dm => this.deliveryMethods = dm
    })
  }

  setShippingPrice(deliveryMethod: DeliveryMethod) {
    this.basketService.setShippingPrice(deliveryMethod);
  }
}
