import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import {
  requiredTextValidator,
  shortTextValidator,
  passwordValidator
} from "ClientApp/app/validators/text-validator";
import { emailValidator } from "ClientApp/app/validators/email-validator";
import { passwordsValidator } from "ClientApp/app/validators/passwords-validator";
import { fileValidator } from "ClientApp/app/validators/file-validator";

@Component({
  selector: "app-informations",
  templateUrl: "./informations.component.html",
  styleUrls: ["./informations.component.scss"]
})
export class InformationsComponent implements OnInit {
  private _user = {
    name: "ania",
    email: "ania@gmail.com",
    link: "czesc, jestem ania",
    description: "moj opis"
  };
  private form: any; // By�o FRORM GROUP TODO GRUBIEJ
  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.form = this.fb.group({
      userName: [this.user.name, [Validators.required, requiredTextValidator]],
      // email: [this.user.email, [Validators.required, emailValidator]],
      shortInformation: [this.user.link, shortTextValidator],
      description: [this.user.description],
      // password: ["", passwordsValidator],
      password: ["", passwordValidator],
      file: ["", fileValidator]
    });
  }

  get user() {
    return this._user;
  }
}
