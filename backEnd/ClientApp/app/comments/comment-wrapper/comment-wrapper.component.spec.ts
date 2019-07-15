import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommentWrapperComponent } from './comment-wrapper.component';

describe('CommentWrapperComponent', () => {
  let component: CommentWrapperComponent;
  let fixture: ComponentFixture<CommentWrapperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CommentWrapperComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommentWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
