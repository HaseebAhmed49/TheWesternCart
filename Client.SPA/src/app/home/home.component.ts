import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MaterialModule } from '../shared/modules/material/material.module';
@Component({
  selector: 'app-home',
  imports: [
    CommonModule,
    MaterialModule
  ],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent {
}