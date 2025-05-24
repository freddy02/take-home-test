import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanListComponentComponent } from './loan-list-component.component';

describe('LoanListComponentComponent', () => {
  let component: LoanListComponentComponent;
  let fixture: ComponentFixture<LoanListComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoanListComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoanListComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
