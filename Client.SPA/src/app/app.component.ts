import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AccountService } from './account/account.service';
import { User } from './shared/models/user';
import { NavBarComponent } from './core/nav-bar/nav-bar.component';
import { MaterialModule } from './shared/modules/material/material.module';
import { NgxSpinner, NgxSpinnerModule } from 'ngx-spinner';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    NavBarComponent,
    MaterialModule,
    NgxSpinnerModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.sass'
})

export class AppComponent implements OnInit {
  title = 'TheWesternCart';

  constructor(private accountService: AccountService, private basketService: BasketService,) {}

  ngOnInit(): void {
    this.loadBasket();
    this.setCurrentUser();

  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }

  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) this.basketService.getBasket(basketId);
  }
}
