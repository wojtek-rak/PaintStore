import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import {
  requiredTextValidator,
  shortTextValidator,
  passwordValidator
} from "ClientApp/app/validators/text-validator";
import { passwordsValidator } from "ClientApp/app/validators/passwords-validator";
import { emailValidator } from "ClientApp/app/validators/email-validator";

@Component({
  selector: "app-credentials",
  templateUrl: "./credentials.component.html",
  styleUrls: ["./credentials.component.scss"]
})
export class CredentialsComponent implements OnInit {
  private form: any;
  private _user = {
    name: "ania",
    email: "ania@gmail.com",
    link: "czesc, jestem ania",
    description: "moj opis"
  };
  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.form = this.fb.group({
      email: [this.user.email, [Validators.required, emailValidator]],
      passwords: ["", passwordsValidator],
      password: ["", passwordValidator]
    });
  }

  get user() {
    return this._user;
  }
}
