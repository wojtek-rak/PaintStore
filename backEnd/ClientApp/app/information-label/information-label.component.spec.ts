import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationLabelComponent } from './information-label.component';

describe('InformationLabelComponent', () => {
  let component: InformationLabelComponent;
  let fixture: ComponentFixture<InformationLabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InformationLabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InformationLabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
