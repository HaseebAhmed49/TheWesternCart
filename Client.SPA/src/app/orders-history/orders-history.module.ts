import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersHistoryRoutingModule } from './orders-history-routing.module';
import { SharedModule } from '../shared/shared.module';
import { OrdersHistoryComponent } from './orders-history/orders-history.component';


@NgModule({
  declarations: [
    // OrdersHistoryComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    OrdersHistoryRoutingModule
  ]
})

export class OrdersHistoryModule { }