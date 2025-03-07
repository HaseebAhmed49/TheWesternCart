import { NgModule } from "@angular/core";
import {RouterModule, Routes } from "@angular/router";
import { OrderDetailedComponent } from "./order-detailed/order-detailed.component";
import { OrdersComponent } from "./orders/orders.component";

const routes: Routes = [
  { path: '', component: OrdersComponent },
  { path: ':id', component: OrderDetailedComponent, data: { breadcrumb: { alias: 'OrderDetailed' } } }
]
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }