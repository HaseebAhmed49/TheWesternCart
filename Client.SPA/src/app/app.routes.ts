import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { NgModule } from '@angular/core';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
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