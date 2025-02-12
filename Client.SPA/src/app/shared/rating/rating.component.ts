import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {RatingService} from './rating.service';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../modules/material/material.module';

@Component({
  selector: 'app-rating',
  imports: [
    CommonModule,
    MaterialModule
  ],
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.sass']
})
export class RatingComponent implements OnInit {
  @Input() public maxRating = 5;
  @Input() public selectedRate = 0;
  @Output() public onRating = new EventEmitter<number>();
  public previousRate = 0;
  public maxRatingArr: number[] = [];
  constructor(private ratingService: RatingService) {
  }
  ngOnInit(): void {
    this.maxRatingArr = Array(this.maxRating).fill(0);
  }
  public handleMouseEnter(index: number) {
    this.selectedRate = index + 1;
  }
  public handleMouseLeave(index: number) {
    this.selectedRate = this.previousRate;
  }
  public rate(index: number) {
    this.selectedRate = index + 1;
    this.previousRate = this.selectedRate;
    this.onRating.emit(this.previousRate);
  }
}