import { Component, OnInit, ViewChild } from "@angular/core";
import { ShortUserInfo } from "../classes/short-user-info";
import { LoggedIn } from "../classes/logged-in";

@Component({
  selector: "app-information-label",
  templateUrl: "./information-label.component.html",
  styleUrls: ["./information-label.component.scss"]
})
export class InformationLabelComponent extends LoggedIn implements OnInit {
  @ViewChild("wrapper") wrapper: any;
  private labelName = "";
  private data: ShortUserInfo[] = [];

  constructor() {
    super();
  }

  ngOnInit() {
    super.ngOnInit();
    document.addEventListener("click", e => {
      if ((<any>e).path[0].classList.contains("message-container")) {
        this.close();
      }
    });
  }

  close() {
    const el = this.wrapper.nativeElement;
    el.classList.remove("opacity");
    setTimeout(() => {
      el.classList.remove("display");

      const nullCheck = document.querySelector("body");
      if (nullCheck === null) {
        return;
      }

      nullCheck.classList.remove("stop-scrolling");
    }, 200);
  }

  show(data: any, name: any) {
    // stop scrolling when label visible
    const nullCheck = document.querySelector("body");
    if (nullCheck === null) return;

    nullCheck.classList.add("stop-scrolling");

    // show element
    const el = this.wrapper.nativeElement;
    el.classList.add("display");
    setTimeout(() => {
      el.classList.add("opacity");
    }, 0);

    // set proper data - this.data is used for displaying users
    this.labelName = name;
    this.data = data;
  }

  getData() {
    return this.data;
  }

  getLabelName() {
    return this.labelName;
  }
}
