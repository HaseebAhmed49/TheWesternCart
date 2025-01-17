import { Component } from '@angular/core';
import { AccountService } from '../account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatError, MatFormField, MatLabel } from '@angular/material/form-field';


@Component({
  selector: 'app-login',
  imports: [
    CommonModule,
    MatCardModule,
    MatFormField,
    MatLabel,
    MatError,
    ReactiveFormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
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
