import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InputPasswordComponent } from './input-password.component';

describe('InputPasswordComponent', () => {
  let component: InputPasswordComponent;
  let fixture: ComponentFixture<InputPasswordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InputPasswordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InputPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
