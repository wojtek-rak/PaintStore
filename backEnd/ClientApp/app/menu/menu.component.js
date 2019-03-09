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
import { Component, ViewChild, ElementRef } from "@angular/core";
import * as $ from "jquery";
import * as ScrollMagic from "ScrollMagic";
import { Router } from "@angular/router";
import { LoginManager } from "../classes/login-manager";
import { LoggedIn } from "../classes/logged-in";
import { AccountService } from "../services/account.service";
var MenuComponent = /** @class */ (function (_super) {
    __extends(MenuComponent, _super);
    function MenuComponent(router, _accountService) {
        var _this = _super.call(this) || this;
        _this.router = router;
        _this._accountService = _accountService;
        _this.host = "http://localhost:4200/";
        _this.loginPage = "http://localhost:4200/homepage";
        return _this;
    }
    MenuComponent.prototype.ngOnInit = function () {
        var _this = this;
        _super.prototype.ngOnInit.call(this);
        // menu on homepage looks differently
        if (this._loggedIn === false) {
            $("menu").addClass("logged-out");
        }
        if (!this.menu.nativeElement.classList.contains("static") &&
            window.location.pathname === "/homepage") {
            this.menu.nativeElement.classList.add("static");
        }
        // hide toggled menu when clicked somewhere on page
        document.addEventListener("click", function (e) {
            if (e.target !== _this.menuToggled.nativeElement &&
                !_this.menuToggled.nativeElement.contains(e.target) &&
                (e.target !== _this.button.nativeElement &&
                    !_this.button.nativeElement.contains(e.target))) {
                _this.menuToggled.nativeElement.classList.remove("visible");
            }
        });
        // scroll menu
        for (var i = 1; i <= 6; i++) {
            var controller = new ScrollMagic.Controller();
            var scene = new ScrollMagic.Scene({
                triggerElement: ".scrollmagic-toggle",
                triggerHook: 0,
                offset: 40
            })
                .setClassToggle(".container-menu", "scrolled")
                .addTo(controller);
        }
    };
    MenuComponent.prototype.toggleMenu = function () {
        this.menuToggled.nativeElement.classList.toggle("visible");
    };
    MenuComponent.prototype.onLogin = function (form) {
        var _this = this;
        this._accountService
            .getUserToken({
            email: form.form.value.email,
            password: form.form.value.password
        })
            .subscribe(function (res) {
            LoginManager.loginUser(res);
            window.location.replace(_this.host);
        }, function (err) {
            _this.input.nativeElement.classList.add("invalid");
            _this.input2.nativeElement.classList.add("invalid");
        });
    };
    MenuComponent.prototype.onKeyup = function () {
        this.input.nativeElement.classList.remove("invalid");
        this.input2.nativeElement.classList.remove("invalid");
    };
    MenuComponent.prototype.logout = function () {
        var _this = this;
        this._accountService
            .logoutUser({ id: this.loggedId }, this._loggedId, this._loggedToken)
            .subscribe(function (res) {
            LoginManager.logoutUser();
            window.location.replace(_this.loginPage);
        });
    };
    __decorate([
        ViewChild("menu"),
        __metadata("design:type", typeof (_a = typeof ElementRef !== "undefined" && ElementRef) === "function" && _a || Object)
    ], MenuComponent.prototype, "menu", void 0);
    __decorate([
        ViewChild("menuToggled"),
        __metadata("design:type", typeof (_b = typeof ElementRef !== "undefined" && ElementRef) === "function" && _b || Object)
    ], MenuComponent.prototype, "menuToggled", void 0);
    __decorate([
        ViewChild("button"),
        __metadata("design:type", typeof (_c = typeof ElementRef !== "undefined" && ElementRef) === "function" && _c || Object)
    ], MenuComponent.prototype, "button", void 0);
    __decorate([
        ViewChild("input"),
        __metadata("design:type", typeof (_d = typeof ElementRef !== "undefined" && ElementRef) === "function" && _d || Object)
    ], MenuComponent.prototype, "input", void 0);
    __decorate([
        ViewChild("input2"),
        __metadata("design:type", typeof (_e = typeof ElementRef !== "undefined" && ElementRef) === "function" && _e || Object)
    ], MenuComponent.prototype, "input2", void 0);
    MenuComponent = __decorate([
        Component({
            selector: "app-menu",
            templateUrl: "./menu.component.html",
            styleUrls: ["./menu.component.scss"]
        }),
        __metadata("design:paramtypes", [typeof (_f = typeof Router !== "undefined" && Router) === "function" && _f || Object, AccountService])
    ], MenuComponent);
    return MenuComponent;
    var _a, _b, _c, _d, _e, _f;
}(LoggedIn));
export { MenuComponent };
//# sourceMappingURL=menu.component.js.map