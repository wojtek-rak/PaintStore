import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgreeLabelComponent } from './agree-label.component';

describe('AgreeLabelComponent', () => {
  let component: AgreeLabelComponent;
  let fixture: ComponentFixture<AgreeLabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgreeLabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgreeLabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
