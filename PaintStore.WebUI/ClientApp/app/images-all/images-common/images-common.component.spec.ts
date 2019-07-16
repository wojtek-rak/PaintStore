import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ImagesCommonComponent } from "./images-common.component";

describe("ImagesCommonComponent", () => {
  let component: ImagesCommonComponent;
  let fixture: ComponentFixture<ImagesCommonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ImagesCommonComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImagesCommonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
