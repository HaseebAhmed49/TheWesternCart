import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClothingDetailsComponent } from './clothing-details/clothing-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  {path: '', component: ShopComponent},
  {path: ':id', component: ClothingDetailsComponent, data: {breadcrumb: {alias: 'clothingDetails'}}},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShopRoutingModule { }
