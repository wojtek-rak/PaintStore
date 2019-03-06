var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var IndexComponent = /** @class */ (function (_super) {
    __extends(IndexComponent, _super);
    function IndexComponent(_accountService, fb, router) {
        var _this = _super.call(this) || this;
        _this._accountService = _accountService;
        _this.fb = fb;
        _this.router = router;
        _this._registered = false;
        _this._registerWarning = "";
        _this._loginWarning = "";
        _this.host = "http://localhost:4200/";
        _this.loginForm = _this.fb.group({
            email: ["", [Validators.required, emailValidator]],
            password: ["", [Validators.required, passwordValidator]]
        });
        _this.registerForm = _this.fb.group({
            email: ["", [Validators.required, emailValidator]],
            passwords: [
                "",
                [Validators.required, requiredTextValidator, passwordsValidator]
            ],
            name: ["", [Validators.required, requiredTextValidator]]
        });
        return _this;
    }
    IndexComponent.prototype.ngOnInit = function () {
        _super.prototype.ngOnInit.call(this);
        this.animateScrolling();
    };
    IndexComponent.prototype.childEmitter = function () {
        this.scrollDown();
    };
    IndexComponent.prototype.scrollDown = function () {
        setTimeout(function () {
            document
                .getElementsByClassName("mat-tab-label-container")[0]
                .scrollIntoView({
                block: "center",
                behavior: "smooth"
            });
        }, 100);
    };
    IndexComponent.prototype.authenticateUser = function (name, password) {
        var _this = this;
        this._accountService
            .getUserToken({
            email: name,
            password: password
        })
            .subscribe(function (res) {
            // to do: walidacja
            LoginManager.loginUser(res);
            window.location.replace(_this.host);
        });
    };
    IndexComponent.prototype.onLogin = function (form) {
        if (form.status === "VALID") {
            this._loginWarning = "";
            this.authenticateUser(form.value.email, form.value.password);
        }
        else {
            this._loginWarning = "Form must be valid.";
        }
    };
    IndexComponent.prototype.onRegister = function (form) {
        var _this = this;
        if (form.status === "VALID") {
            this._registerWarning = "";
            this._accountService
                .registerUser({
                name: form.value.name,
                email: form.value.email,
                password: form.value.passwords.new
            })
                .subscribe(function (res) {
                console.log(res);
                // to do: walidacja
                _this._registered = true;
            });
        }
        else {
            this._registerWarning = "Form must be valid.";
        }
    };
    IndexComponent.prototype.animateScrolling = function () {
        var name = ".img";
        for (var i = 1; i <= 6; i++) {
            var controller = new ScrollMagic.Controller();
            var scene = new ScrollMagic.Scene({
                triggerElement: name + i,
                triggerHook: 0.9
            })
                .setClassToggle(name + i, "visible")
                .addTo(controller);
        }
    };
    Object.defineProperty(IndexComponent.prototype, "registered", {
        get: function () {
            return this._registered;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(IndexComponent.prototype, "registerWarning", {
        get: function () {
            return this._registerWarning;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(IndexComponent.prototype, "loginWarning", {
        get: function () {
            return this._loginWarning;
        },
        enumerable: true,
        configurable: true
    });
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
    return IndexComponent;
}(LoggedIn));
export { IndexComponent };
//# sourceMappingURL=index.component.js.map