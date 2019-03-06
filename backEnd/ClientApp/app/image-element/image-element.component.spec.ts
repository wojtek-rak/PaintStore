import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageElementComponent } from './image-element.component';

describe('ImageElementComponent', () => {
  let component: ImageElementComponent;
  let fixture: ComponentFixture<ImageElementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImageElementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImageElementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
