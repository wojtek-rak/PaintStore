import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmationMessageComponent } from './confirmation-message.component';

describe('ConfirmationMessageComponent', () => {
  let component: ConfirmationMessageComponent;
  let fixture: ComponentFixture<ConfirmationMessageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmationMessageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmationMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
