import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationsComponent } from './informations.component';

describe('InformationsComponent', () => {
  let component: InformationsComponent;
  let fixture: ComponentFixture<InformationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InformationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InformationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
