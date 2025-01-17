import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, FormGroup, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';
import { debounceTime, finalize, map, switchMap, take } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { MatCard, MatCardModule } from '@angular/material/card';
import { MatError, MatFormField, MatLabel } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatOption } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-register',
  imports: [
    CommonModule,
    MatCardModule,
    MatFormField,
    MatLabel,
    MatError,
    MatDatepickerModule,
    MatSelectModule,
    MatOption,
    ReactiveFormsModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent  implements OnInit {
  hide = true;
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup = new FormGroup({});
  maxDate: Date = new Date();
  validationErrors: string[] | undefined;
  complexPassword = "(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+}{\":;'?/<>.,])(?!.*\\s).*$";
  constructor(private accountService: AccountService, private toastr: ToastrService,
              private fb: FormBuilder, private router: Router) {
  }
  ngOnInit(): void {
    this.initializeForm();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }
  initializeForm() {
    this.registerForm = this.fb.group({
      gender: ['male'],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      email: ['', [Validators.required, Validators.email], [this.validateEmailNotTaken()]],
      password: ['', [Validators.required, Validators.pattern(this.complexPassword)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]],
    });
    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmPassword'].updateValueAndValidity()
    });
  }
  register() {
    const dob = this.getDateOnly(this.registerForm.controls['dateOfBirth'].value);
    const values = { ...this.registerForm.value, dateOfBirth: dob };
    this.accountService.register(values).subscribe({
      next: () => {
        this.router.navigateByUrl('/shop');
      },
      error: error => {
        this.validationErrors = error;
        this.toastr.error('Registration failed');
      }
    });
  }
  validateEmailNotTaken(): AsyncValidatorFn {
    return (control: AbstractControl) => {
      return control.valueChanges.pipe(
        debounceTime(1000),
        take(1),
        switchMap(() => {
          return this.accountService.checkEmailExists(control.value).pipe(
            map(result => result ? { emailExists: true } : null),
            finalize(() => control.markAsTouched())
          );
        })
      );
    };
  }
  private getDateOnly(dob: string | undefined) {
    if (!dob) return;
    let theDob = new Date(dob);
    return new Date(theDob.setMinutes(theDob.getMinutes() - theDob.getTimezoneOffset()))
      .toISOString().slice(0, 10);
  }
  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : { notMatching: true };
    };
  }
  cancel() {
    this.registerForm.reset();
    this.cancelRegister.emit(false);
  }
}