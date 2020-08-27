import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTurnComponent } from './get-turn.component';

describe('GetTurnComponent', () => {
  let component: GetTurnComponent;
  let fixture: ComponentFixture<GetTurnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetTurnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetTurnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
