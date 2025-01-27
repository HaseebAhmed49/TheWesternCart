import {Component} from '@angular/core';
import { AccountService } from '../../account/account.service';
import { BasketService } from '../../basket/basket.service';
import { BasketItem } from '../../shared/models/basket';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { CommonModule } from '@angular/common';
import { RouterLinkActive } from '@angular/router';
import { HasRoleDirective } from '../directives/has-role.directive';

@Component({
  selector: 'app-nav-bar',
    imports: [
      MaterialModule,
      CommonModule,
      RouterLinkActive,
      HasRoleDirective
    ],
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