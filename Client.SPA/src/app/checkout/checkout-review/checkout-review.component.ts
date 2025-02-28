import { Component, Input } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { ToastrService } from 'ngx-toastr';
import { CdkStepper } from '@angular/cdk/stepper';
import { BasketSummaryComponent } from '../../shared/basket-summary/basket-summary.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { MaterialModule } from '../../shared/modules/material/material.module';

@Component({
  selector: 'app-checkout-review',
  imports: [
    CommonModule,
    SharedModule,
    MaterialModule
  ],
  templateUrl: './checkout-review.component.html',
  styleUrl: './checkout-review.component.sass'
})
export class CheckoutReviewComponent {
  @Input() appStepper?: CdkStepper;

  constructor(private basketService: BasketService, private toastr: ToastrService) {
  }

  createPaymentIntent() {
    this.basketService.createPaymentIntent().subscribe({
      next: () => {
        this.appStepper?.next();
      },
      error: error => this.toastr.error(error.message)
    })
  }
}
