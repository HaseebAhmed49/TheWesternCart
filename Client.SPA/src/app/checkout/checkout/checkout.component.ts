import {Component, OnInit} from '@angular/core';
import { AccountService } from '../../account/account.service';
import { UsersService } from '../../users/users.service';
import { BasketService } from '../../basket/basket.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MaterialModule } from '../../shared/modules/material/material.module';
import { CheckoutAddressComponent } from '../checkout-address/checkout-address.component';
import { CheckoutPaymentComponent } from '../checkout-payment/checkout-payment.component';
import { CheckoutDeliveryComponent } from '../checkout-delivery/checkout-delivery.component';
import { CheckoutReviewComponent } from '../checkout-review/checkout-review.component';
import { SharedModule } from '../../shared/shared.module';

@Component({
  selector: 'app-checkout',
  imports:[
    MaterialModule,
    CheckoutAddressComponent,
    CheckoutPaymentComponent,
    CheckoutDeliveryComponent,
    CheckoutReviewComponent,
    SharedModule
  ],
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.sass']
})
export class CheckoutComponent implements OnInit {
  constructor(private fb: FormBuilder, private accountService: AccountService, private usersService: UsersService,
              private basketService: BasketService) { }

  ngOnInit(): void {
    this.checkoutForm = this.fb.group({
      addressForm: this.fb.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        country: ['', Validators.required],
        city: ['', Validators.required],
        state: ['', Validators.required],
        addressLine: ['', Validators.required],
        postalCode: ['', Validators.required],
      }),
      deliveryForm: this.fb.group({
        deliveryMethod: ['', Validators.required]
      }),
      paymentForm: this.fb.group({
        nameOnCard: ['', Validators.required]
      })
    });
    this.getAddressFormValues();
    this.getDeliveryMethodValue();
  }

  checkoutForm!: FormGroup;

  getAddressFormValues() {
    this.usersService.getUserAddress().subscribe({
      next: address => {
        address && this.checkoutForm.get('addressForm')?.patchValue(address);
      }
    });
  }

  getDeliveryMethodValue() {
    const basket = this.basketService.getCurrentBasketValue();
    if (basket && basket.deliveryMethodId) {
      this.checkoutForm.get('deliveryForm')?.get('deliveryMethod')?.patchValue(basket.deliveryMethodId.toString());
    }
  }

  get addressForm(): FormGroup {
    return this.checkoutForm.get('addressForm') as FormGroup;
  }

  get deliveryForm(): FormGroup {
    return this.checkoutForm.get('deliveryForm') as FormGroup;
  }

  get paymentForm(): FormGroup {
    return this.checkoutForm.get('paymentForm') as FormGroup;
  }
}
