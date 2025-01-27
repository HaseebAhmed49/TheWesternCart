import { Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';

export const routes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {
        path: 'account',
        loadChildren: () => import('./account/account.module').then(m => m.AccountModule),
        data: {breadcrumb: {skip: true}}
      },
      {path: '**', redirectTo: '', pathMatch: 'full'},
];
