import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import * as $ from "jquery";
import { NgForm, FormGroup, FormBuilder, Validators } from "@angular/forms";
import { FormValidationModel } from "../form-validation-model";
import { ValidMessage } from "../valid-message";
import { FormResponse } from "../form-response";
import * as ScrollMagic from "ScrollMagic";
import { AccountService } from "../services/account.service";
import {
  requiredTextValidator,
  passwordValidator
} from "../validators/text-validator";
import { emailValidator } from "../validators/email-validator";
import { passwordsValidator } from "../validators/passwords-validator";
import { LocalStorageService } from "angular-web-storage";
import { StorageData } from "../classes/storage-data";
import { LoginManager } from "../classes/login-manager";
import { LoggedIn } from "../classes/logged-in";
import { Router } from "@angular/router";

@Component({
  selector: "app-index",
  templateUrl: "./index.component.html",
  styleUrls: ["./index.component.scss"]
})
export class IndexComponent extends LoggedIn implements OnInit {
  // private _loggedIn = false;

  registerForm: FormGroup;
  loginForm: FormGroup;

  private _registered = false;
  private _registerWarning = "";
  private _loginWarning = "";
  private host = "http://localhost:4200/";

  constructor(
    private _accountService: AccountService,
    private fb: FormBuilder,
    private router: Router
  ) {
    super();
    this.loginForm = this.fb.group({
      email: ["", [Validators.required, emailValidator]],
      password: ["", [Validators.required, passwordValidator]]
    });

    this.registerForm = this.fb.group({
      email: ["", [Validators.required, emailValidator]],
      passwords: [
        "",
        [Validators.required, requiredTextValidator, passwordsValidator]
      ],
      name: ["", [Validators.required, requiredTextValidator]]
    });
  }

  ngOnInit() {
    super.ngOnInit();
    this.animateScrolling();
  }

  childEmitter() {
    this.scrollDown();
  }

  scrollDown() {
    setTimeout(() => {
      document
        .getElementsByClassName("mat-tab-label-container")[0]
        .scrollIntoView({
          block: "center",
          behavior: "smooth"
        });
    }, 100);
  }

  authenticateUser(name: string, password: string) {
    this._accountService
      .getUserToken({
        email: name,
        password: password
      })
      .subscribe(res => {
        // to do: walidacja
        LoginManager.loginUser(res);
        window.location.replace(this.host);
      });
  }

  onLogin(form: NgForm) {
    if (form.status === "VALID") {
      this._loginWarning = "";
      this.authenticateUser(form.value.email, form.value.password);
    } else {
      this._loginWarning = "Form must be valid.";
    }
  }

  onRegister(form: NgForm) {
    if (form.status === "VALID") {
      this._registerWarning = "";
      this._accountService
        .registerUser({
          name: form.value.name,
          email: form.value.email,
          password: form.value.passwords.new
        })
        .subscribe(res => {
          console.log(res);
          // to do: walidacja
          this._registered = true;
        });
    } else {
      this._registerWarning = "Form must be valid.";
    }
  }

  animateScrolling() {
    let name = ".img";
    for (let i = 1; i <= 6; i++) {
      let controller = new ScrollMagic.Controller();
      let scene = new ScrollMagic.Scene({
        triggerElement: name + i,
        triggerHook: 0.9
      })
        .setClassToggle(name + i, "visible")
        .addTo(controller);
    }
  }

  get registered() {
    return this._registered;
  }

  get registerWarning() {
    return this._registerWarning;
  }

  get loginWarning() {
    return this._loginWarning;
  }

  // get loggedIn() {
  //   return this._loggedIn;
  // }
}
