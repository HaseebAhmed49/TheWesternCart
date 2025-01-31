import { Component } from '@angular/core';
import { BasketService } from '../basket.service';
import { BasketItem } from '../../shared/models/basket';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { SharedModule } from '../../shared/shared.module';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-basket',
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
    RouterModule
  ],
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.sass']
})

export class BasketComponent {
  constructor(public basketService: BasketService) {}
  incrementQuantity(item: BasketItem) {
    this.basketService.addItemToBasket(item);
  }
  removeItem(event: {id: string, quantity: number}) {
    this.basketService.removeItemFromBasket(event.id, event.quantity);
  }
}