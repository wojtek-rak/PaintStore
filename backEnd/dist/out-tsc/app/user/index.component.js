var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import * as ScrollMagic from "ScrollMagic";
import { AccountService } from "../services/account.service";
import { requiredTextValidator, passwordValidator } from "../validators/text-validator";
import { emailValidator } from "../validators/email-validator";
import { passwordsValidator } from "../validators/passwords-validator";
import { LoginManager } from "../classes/login-manager";
import { LoggedIn } from "../classes/logged-in";
import { Router } from "@angular/router";
let IndexComponent = class IndexComponent extends LoggedIn {
    constructor(_accountService, fb, router) {
        super();
        this._accountService = _accountService;
        this.fb = fb;
        this.router = router;
        this._registered = false;
        this._registerWarning = "";
        this._loginWarning = "";
        this.host = "http://localhost:4200/";
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
    authenticateUser(name, password) {
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
    onLogin(form) {
        if (form.status === "VALID") {
            this._loginWarning = "";
            this.authenticateUser(form.value.email, form.value.password);
        }
        else {
            this._loginWarning = "Form must be valid.";
        }
    }
    onRegister(form) {
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
        }
        else {
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
};
IndexComponent = __decorate([
    Component({
        selector: "app-index",
        templateUrl: "./index.component.html",
        styleUrls: ["./index.component.scss"]
    }),
    __metadata("design:paramtypes", [AccountService,
        FormBuilder,
        Router])
], IndexComponent);
export { IndexComponent };
//# sourceMappingURL=index.component.js.map