import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SharedModule } from '../shared/shared.module';
import { MatOption } from '@angular/material/core';
import { MatError, MatFormField, MatLabel, MatSelectModule } from '@angular/material/select';
import { MatCardContent, MatCardModule } from '@angular/material/card';
import { AccountRoutingModule } from './account-routing.module';

@NgModule({
  // declarations: [
  //   LoginComponent,
  //   RegisterComponent    
  // ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule,
    MatOption,
    MatSelectModule,
    MatCardModule,
    MatCardContent,
    MatFormField,
    MatLabel,
    MatError,
    MatFormField,
    
  ]
})
export class AccountModule { }
