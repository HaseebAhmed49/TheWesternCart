import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { NgModule } from '@angular/core';

export const routes: Routes = [
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