import { Component, Input } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { ClothingItem } from '../../shared/models/clothing-item';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-clothing-item',
  imports: [
    MaterialModule,
    CommonModule,
    RouterModule
  ],
  templateUrl: './clothing-item.component.html',
  styleUrl: './clothing-item.component.sass'
})
export class ClothingItemComponent {
  @Input() product?: ClothingItem;
  constructor(private basketService: BasketService) { }
  addItemToBasket() {
    this.product && this.basketService.addItemToBasket(this.product);
  }
}
