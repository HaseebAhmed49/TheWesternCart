import {Component} from '@angular/core';
import {AccountService} from '../account.service';
import {ActivatedRoute, Router} from '@angular/router';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {environment} from '../../../environments/environment';
import { MatOption, MatOptionModule } from '@angular/material/core';
import { MatError, MatFormField, MatLabel, MatSelect, MatSelectModule } from '@angular/material/select';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatCardContent, MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
@Component({
  selector: 'app-login',
  imports:[
      CommonModule,
      ReactiveFormsModule,
      MatLabel,
      MatError,
      MatOptionModule,
      MatFormField,
      MatCardModule,
      MatCardContent,
      MatFormFieldModule,
      MatInput
    ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent {
  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required)
  });
  returnUrl: string;
  errorMessage: string = '';
  showError: boolean = false;
  baseUrl = environment.apiUrl;
  constructor(private accountService: AccountService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'] || '/shop';
  }
  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe({
      next: () => this.router.navigateByUrl(this.returnUrl),
      error: (err) => {
        this.errorMessage = err.error;
        this.showError = true;
      }
    });
  }
}