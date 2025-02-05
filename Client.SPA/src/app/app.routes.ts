import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { NgModule } from '@angular/core';
import { authGuard } from './core/guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { FavouritesComponent } from './favourites/favourites.component';

export const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      {path: 'favorites', component: FavouritesComponent},
      {
        path: 'orders',
        canActivate: [authGuard],
        loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule)
      },
      {
        path: 'orderhistory',
        canActivate: [authGuard],
        loadChildren: () => import('./orders-history/orders-history.module').then(m => m.OrdersHistoryModule)
      },
    ]
  },
  {
    path: 'shop', loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule),
    data: {breadcrumb: 'Shop'}
  },
  {
    path: 'basket', loadChildren: () => import('./basket/basket.module').then(m => m.BasketModule),
    data: {breadcrumb: 'Basket'}
  },
  {
    path: 'account',
    loadChildren: () => import('./account/account.module').then(m => m.AccountModule),
    data: {breadcrumb: {skip: true}}
    },
  {path: '**', redirectTo: '', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}