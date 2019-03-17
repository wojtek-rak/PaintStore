import { Component, OnInit, ViewChild } from "@angular/core";
import { NgForm, FormGroup, FormBuilder, Validators } from "@angular/forms";
import { shortTextValidator } from "../validators/text-validator";
import { requiredTextValidator } from "../validators/text-validator";
import { emailValidator } from "../validators/email-validator";
import { passwordsValidator } from "../validators/passwords-validator";
import { fileValidator } from "../validators/file-validator";
import { LoggedIn } from "../classes/logged-in";
import { Router } from "@angular/router";
import { ImageService } from "../services/image.service";

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

  onFormUpload(form: NgForm) {
    console.log(form);
  }
}
