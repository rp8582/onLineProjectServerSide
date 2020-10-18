import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CashierLoginComponent } from './cashier-login.component';

describe('CashierLoginComponent', () => {
  let component: CashierLoginComponent;
  let fixture: ComponentFixture<CashierLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CashierLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CashierLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
