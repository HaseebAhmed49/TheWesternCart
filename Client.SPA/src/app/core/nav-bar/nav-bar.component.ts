import {Component} from '@angular/core';
import { AccountService } from '../../account/account.service';
import { BasketService } from '../../basket/basket.service';
import { BasketItem } from '../../shared/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.sass']
})

export class NavBarComponent {
  constructor(public basketService: BasketService, public accountService: AccountService) {
  }
  getCount(items: BasketItem[]) {
    return items.reduce((sum, item) => sum + item.quantity, 0);
  }
}