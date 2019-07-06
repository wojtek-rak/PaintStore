import { Component, OnInit } from "@angular/core";
import { LoggedIn } from "../../logic/classes/logged-in";
import { Router } from "@angular/router";

@Component({
  selector: "app-settings",
  templateUrl: "./settings.component.html",
  styleUrls: ["./settings.component.scss"]
})
export class SettingsComponent extends LoggedIn implements OnInit {
  constructor(private router: Router) {
    super();
  }

  ngOnInit() {
    super.ngOnInit();

    if (this._loggedIn === false) {
      this.router.navigateByUrl("/not-found");
    }
  }
}
