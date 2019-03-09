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
import { shortTextValidator } from "../validators/text-validator";
import { requiredTextValidator } from "../validators/text-validator";
import { emailValidator } from "../validators/email-validator";
import { passwordsValidator } from "../validators/passwords-validator";
import { fileValidator } from "../validators/file-validator";
var SettingsComponent = /** @class */ (function () {
    function SettingsComponent(fb) {
        this.fb = fb;
        this._user = {
            name: "ania",
            email: "ania@gmail.com",
            link: "czesc, jestem ania",
            description: "moj opis"
        };
    }
    SettingsComponent.prototype.ngOnInit = function () {
        this.form = this.fb.group({
            userName: [this.user.name, [Validators.required, requiredTextValidator]],
            email: [this.user.email, [Validators.required, emailValidator]],
            shortInformation: [this.user.link, shortTextValidator],
            description: [this.user.description],
            password: ["", passwordsValidator],
            file: ["", fileValidator]
        });
    };
    SettingsComponent.prototype.onFormUpload = function (form) {
        console.log(form);
    };
    Object.defineProperty(SettingsComponent.prototype, "user", {
        get: function () {
            return this._user;
        },
        enumerable: true,
        configurable: true
    });
    SettingsComponent = __decorate([
        Component({
            selector: "app-settings",
            templateUrl: "./settings.component.html",
            styleUrls: ["./settings.component.scss"]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof FormBuilder !== "undefined" && FormBuilder) === "function" && _a || Object])
    ], SettingsComponent);
    return SettingsComponent;
    var _a;
}());
export { SettingsComponent };
//# sourceMappingURL=settings.component.js.map