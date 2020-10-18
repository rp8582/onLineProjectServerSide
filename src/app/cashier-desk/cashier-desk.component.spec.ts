import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CashierDeskComponent } from './cashier-desk.component';

describe('CashierDeskComponent', () => {
  let component: CashierDeskComponent;
  let fixture: ComponentFixture<CashierDeskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CashierDeskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CashierDeskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
