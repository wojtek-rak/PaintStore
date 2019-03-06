import { Component, OnInit, ViewChild, Input } from "@angular/core";
import { ShortUserInfo } from "../classes/short-user-info";
import { IsUserLoggedIn } from "../classes/is-user-logged-in";
import { LoggedIn } from "../classes/logged-in";

@Component({
  selector: "app-information-label",
  templateUrl: "./information-label.component.html",
  styleUrls: ["./information-label.component.scss"]
})
export class InformationLabelComponent extends LoggedIn implements OnInit {
  @ViewChild("wrapper") wrapper;
  // @Input() loggedUser: IsUserLoggedIn;
  private labelName: string;
  private data: ShortUserInfo[];

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
      document.querySelector("body").classList.remove("stop-scrolling");
    }, 200);
  }

  show(data, name) {
    // stop scrolling when label visible
    document.querySelector("body").classList.add("stop-scrolling");

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

  // emitter($event) {
  //   console.log($event);
  //   if ($event === true) {
  //     console.log("wlasnie zafollowano");
  //   } else {
  //     console.log("unfollow");
  //   }
  // }

  getData() {
    return this.data;
  }

  getLabelName() {
    return this.labelName;
  }
}
