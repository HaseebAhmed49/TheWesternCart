import { CommonModule } from '@angular/common';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatStepper } from '@angular/material/stepper';
import { MaterialModule } from '../modules/material/material.module';
@Component({
  selector: 'app-stepper',
  imports: [
    CommonModule,
    MaterialModule
  ],
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.sass'],
  providers: [{provide: MatStepper, useExisting: StepperComponent}]
})
export class StepperComponent extends MatStepper  implements OnInit, OnDestroy  {
  @Input() linearModeSelected = true;
  ngOnInit(): void {
    this.linear = this.linearModeSelected;
  }
  onClick(index: number) {
    this.selectedIndex = index;
  }
}