import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClothingItemComponent } from './clothing-item.component';

describe('ClothingItemComponent', () => {
  let component: ClothingItemComponent;
  let fixture: ComponentFixture<ClothingItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClothingItemComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClothingItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
