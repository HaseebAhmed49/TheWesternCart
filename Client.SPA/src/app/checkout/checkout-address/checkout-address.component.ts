import { Component, Input } from '@angular/core';
import { UsersService } from '../../users/users.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { MaterialModule } from '../../shared/modules/material/material.module';

@Component({
  selector: 'app-checkout-address',
  imports: [
    CommonModule,
    SharedModule,
    MaterialModule
  ],
  templateUrl: './checkout-address.component.html',
  styleUrl: './checkout-address.component.sass'
})
export class CheckoutAddressComponent {
  @Input() checkoutForm?: FormGroup;

  constructor(private usersService: UsersService, private toastr: ToastrService) {}

  saveUserAddress() {
    this.usersService.updateUserAddress(this.checkoutForm?.get('addressForm')?.value).subscribe({
      next: () => {
        this.toastr.success('Address saved');
        this.checkoutForm?.get('addressForm')?.reset(this.checkoutForm?.get('addressForm')?.value);
      }
    })
  }
}
