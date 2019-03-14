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
import { GlobalVariables } from "../classes/global-variables";
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
  @ViewChild("email") email;
  @ViewChild("name") name;
  @ViewChild("emailLogin") emailLogin;
  @ViewChild("passwordLogin") passwordLogin;

  registerForm: FormGroup;
  loginForm: FormGroup;

  private _registered = false;
  private _registerWarning = "";
  private _loginWarning = "";
  private host = "http://localhost:4200/";
  private recaptcha = false;
  private _loginLoading = false;
  private _registerLoading = false;

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
      name: ["", [Validators.required, requiredTextValidator]],
      captcha: [null, Validators.required]
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
      .subscribe(
        res => {
          // to do: walidacja
          LoginManager.loginUser(res);
          window.location.replace("");
          // document.location.reload();
          this._loginLoading = false;
        },
        err => {
          this._loginLoading = false;
          // console.log(this.passwordLogin.Input.nativeElement.classList.add('invalid'));
          if (err.status === 401) {
            this.emailLogin.Input.nativeElement.classList.add("invalid");
            this.passwordLogin.Input.nativeElement.classList.add("invalid");
            this._loginWarning =
              "Cannot find a user with given name and password.";
          }
        }
      );
  }

  onLogin(form: NgForm) {
    if (form.status === "VALID") {
      this._loginLoading = true;
      this._loginWarning = "";
      this.authenticateUser(form.value.email, form.value.password);
    } else {
      this._loginWarning = "Form must be valid.";
    }
  }

  onRegister(form: NgForm) {
    if (form.status === "VALID" && this.recaptcha) {
      this._registerLoading = true;
      this._registerWarning = "";
      this._accountService
        .registerUser({
          name: form.value.name,
          email: form.value.email,
          password: form.value.passwords.new
        })
        .subscribe(
          res => {
            this._registered = true;
            this._registerLoading = false;
          },
          err => {
            this._registerLoading = false;
            // email already exists
            if (err.status === 409) {
              this.email.validateMessage = "Email already exists!";
            }
            // username already exists
            if (err.status === 403) {
              this.name.validateMessage = "Name already exists!";
            }
          }
        );
    } else {
      this._registerWarning = "All fields must be filled.";
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

  resolved($e) {
    this.recaptcha = true;
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

  get registerLoading() {
    return this._registerLoading;
  }

  get loginLoading() {
    return this._loginLoading;
  }
  // get loggedIn() {
  //   return this._loggedIn;
  // }
}
