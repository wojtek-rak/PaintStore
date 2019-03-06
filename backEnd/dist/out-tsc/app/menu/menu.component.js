var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewChild } from "@angular/core";
import * as $ from "jquery";
import * as ScrollMagic from "ScrollMagic";
import { Router } from "@angular/router";
import { LoginManager } from "../classes/login-manager";
import { LoggedIn } from "../classes/logged-in";
import { AccountService } from "../services/account.service";
let MenuComponent = class MenuComponent extends LoggedIn {
    constructor(router, _accountService) {
        super();
        this.router = router;
        this._accountService = _accountService;
        this.host = "http://localhost:4200/";
        this.loginPage = "http://localhost:4200/homepage";
    }
    ngOnInit() {
        super.ngOnInit();
        // menu on homepage looks differently
        if (this._loggedIn === false) {
            $("menu").addClass("logged-out");
        }
        if (!this.menu.nativeElement.classList.contains("static") &&
            window.location.pathname === "/homepage") {
            this.menu.nativeElement.classList.add("static");
        }
        // hide toggled menu when clicked somewhere on page
        document.addEventListener("click", e => {
            if (e.target !== this.menuToggled.nativeElement &&
                !this.menuToggled.nativeElement.contains(e.target) &&
                (e.target !== this.button.nativeElement &&
                    !this.button.nativeElement.contains(e.target))) {
                this.menuToggled.nativeElement.classList.remove("visible");
            }
        });
        // scroll menu
        for (let i = 1; i <= 6; i++) {
            let controller = new ScrollMagic.Controller();
            let scene = new ScrollMagic.Scene({
                triggerElement: ".scrollmagic-toggle",
                triggerHook: 0,
                offset: 40
            })
                .setClassToggle(".container-menu", "scrolled")
                .addTo(controller);
        }
    }
    toggleMenu() {
        this.menuToggled.nativeElement.classList.toggle("visible");
    }
    onLogin(form) {
        this._accountService
            .getUserToken({
            email: form.form.value.email,
            password: form.form.value.password
        })
            .subscribe(res => {
            LoginManager.loginUser(res);
            window.location.replace(this.host);
        }, err => {
            this.input.nativeElement.classList.add("invalid");
            this.input2.nativeElement.classList.add("invalid");
        });
    }
    onKeyup() {
        this.input.nativeElement.classList.remove("invalid");
        this.input2.nativeElement.classList.remove("invalid");
    }
    logout() {
        this._accountService
            .logoutUser({ id: this.loggedId }, this._loggedId, this._loggedToken)
            .subscribe(res => {
            LoginManager.logoutUser();
            window.location.replace(this.loginPage);
        });
    }
};
__decorate([
    ViewChild("menu"),
    __metadata("design:type", Object)
], MenuComponent.prototype, "menu", void 0);
__decorate([
    ViewChild("menuToggled"),
    __metadata("design:type", Object)
], MenuComponent.prototype, "menuToggled", void 0);
__decorate([
    ViewChild("button"),
    __metadata("design:type", Object)
], MenuComponent.prototype, "button", void 0);
__decorate([
    ViewChild("input"),
    __metadata("design:type", Object)
], MenuComponent.prototype, "input", void 0);
__decorate([
    ViewChild("input2"),
    __metadata("design:type", Object)
], MenuComponent.prototype, "input2", void 0);
MenuComponent = __decorate([
    Component({
        selector: "app-menu",
        templateUrl: "./menu.component.html",
        styleUrls: ["./menu.component.scss"]
    }),
    __metadata("design:paramtypes", [Router, AccountService])
], MenuComponent);
export { MenuComponent };
//# sourceMappingURL=menu.component.js.map