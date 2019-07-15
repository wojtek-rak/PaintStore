import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommentsLogicComponent } from './comments-logic.component';

describe('CommentsLogicComponent', () => {
  let component: CommentsLogicComponent;
  let fixture: ComponentFixture<CommentsLogicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CommentsLogicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommentsLogicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
