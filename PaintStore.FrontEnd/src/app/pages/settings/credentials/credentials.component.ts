import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, Validators, NgForm } from "@angular/forms";
import {
  requiredTextValidator,
  shortTextValidator,
  passwordValidator
} from "ClientApp/app/logic/validators/text-validator";
import { passwordsValidator } from "ClientApp/app/logic/validators/passwords-validator";
import { emailValidator } from "ClientApp/app/logic/validators/email-validator";
import { ImageService } from "ClientApp/app/services/image.service";
import { LoggedIn } from "ClientApp/app/logic/classes/logged-in";
import { NgForOf } from "@angular/common";
import { LoginManager } from "ClientApp/app/logic/classes/login-manager";

@Component({
  selector: "app-credentials",
  templateUrl: "./credentials.component.html",
  styleUrls: ["./credentials.component.scss"]
})
export class CredentialsComponent extends LoggedIn implements OnInit {
  private form: any;
  private _email = "";
  private _warning = "";
  @ViewChild("msg") msg;

  constructor(private fb: FormBuilder, private service: ImageService) {
    super();
  }

  initializeForm() {
    this.form = this.fb.group({
      email: [this._email, [Validators.required, emailValidator]],
      passwords: ["", passwordsValidator],
      password: ["", [Validators.required, passwordValidator]]
    });
  }

  getUserEmail() {
    this.service
      .getUserEmail(
        { userId: this._loggedId },
        this._loggedId,
        this._loggedToken
      )
      .subscribe((res: any) => {
        this._email = res.email;
        this.initializeForm();
      });
  }

  ngOnInit() {
    super.ngOnInit();
    this.getUserEmail();
  }

  onFormUpload(form: NgForm) {
    if (form.status === "INVALID") {
      this._warning = "Email and password must be given.";
    } else {
      this._warning = "";
      const data = {
        id: this._loggedId,
        oldPassword: form.value.password,
        newEmail: form.value.email,
        newPassword:
          form.value.passwords.new === "" ? null : form.value.passwords.new,
        oldEmail: this._email
      };

      this.service
        .editUserCredentials(data, this._loggedId, this._loggedToken)
        .subscribe(
          res => {
            LoginManager.logoutUser();
            window.location.replace("homepage");
          },
          err => {
            if (err.status === 401) this._warning = "Password is invalid.";
            if (err.status === 409) this._warning = "Email arleady exists.";
          }
        );
    }
  }

  get email() {
    return this._email;
  }

  get warning() {
    return this._warning;
  }
}
