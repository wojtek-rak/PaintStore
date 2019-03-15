import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, Validators, NgForm } from "@angular/forms";
import {
  requiredTextValidator,
  shortTextValidator,
  passwordValidator
} from "ClientApp/app/validators/text-validator";
import { passwordsValidator } from "ClientApp/app/validators/passwords-validator";
import { emailValidator } from "ClientApp/app/validators/email-validator";
import { ImageService } from "ClientApp/app/services/image.service";
import { LoggedIn } from "ClientApp/app/classes/logged-in";
import { NgForOf } from "@angular/common";

@Component({
  selector: "app-credentials",
  templateUrl: "./credentials.component.html",
  styleUrls: ["./credentials.component.scss"]
})
export class CredentialsComponent extends LoggedIn implements OnInit {
  private form: any;
  private _email: string = "";
  private _warning: string = "";
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
      let data = {
        id: this._loggedId,
        oldPassword: form.value.password,
        newEmail: form.value.email,
        newPassword: form.value.password === "" ? null : form.value.password,
        oldEmail: this._email
      };

      console.log(data);
      this.service
        .editUserCredentials(data, this._loggedId, this._loggedToken)
        .subscribe(
          res => {
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
