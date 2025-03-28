import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, ValidatorFn, AsyncValidatorFn, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../account.service';
import { debounceTime, finalize, map, switchMap, take } from 'rxjs/operators';
import { MatNativeDateModule, MatOption, MatOptionModule } from '@angular/material/core';
import { MatError, MatFormField, MatLabel, MatSelect, MatSelectModule } from '@angular/material/select';
import { MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { MatCard, MatCardContent } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';


@Component({
  selector: 'app-register',
  imports:[
    CommonModule,    
    ReactiveFormsModule,    
    MatOption,
    MatSelect,
    MatLabel,
    MatError,
    MatOptionModule,
    MatSelect,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormField,
    MatCard,
    MatCardContent,
    MatFormFieldModule,
    MatInput
  ],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit {
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