import {Component} from '@angular/core';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-order-totals',
  standalone: false,
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.sass']
})

export class OrderTotalsComponent {
  constructor(public basketService: BasketService) {
  }
}