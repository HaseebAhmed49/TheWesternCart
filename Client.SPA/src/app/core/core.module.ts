import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmDialogComponent } from './modals/confirm-dialog/confirm-dialog.component';
import { RolesModalComponent } from './modals/roles-modal/roles-modal.component';
import { HasRoleDirective } from './directives/has-role.directive';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { NavBarComponent } from './nav-bar/nav-bar.component';



@NgModule({
  declarations: [
    HasRoleDirective,
    ConfirmDialogComponent,
    RolesModalComponent,
    NavBarComponent,
  ],
  imports: [
    MatDialogModule,
    FormsModule,
    NgxSpinnerModule,
    SharedModule,
    CommonModule,
    RouterModule,
    ToastrModule.forRoot(
      { positionClass: 'toast-bottom-right',
        preventDuplicates: true})
  ],
  exports: [
    NavBarComponent,
  ]
})
export class CoreModule { }
