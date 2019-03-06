var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, forwardRef, ViewChild } from "@angular/core";
import { NG_VALUE_ACCESSOR, NG_VALIDATORS } from "@angular/forms";
import { InputField } from "../input-field";
import { passwordsValidator } from "../../validators/passwords-validator";
let ConfirmPasswordComponent = ConfirmPasswordComponent_1 = class ConfirmPasswordComponent extends InputField {
    constructor() {
        super();
    }
    stopEditing() {
        this.confirm.nativeElement.value = "";
        super.stopEditing();
    }
    validate(c) {
        const checkUndefinded = this.data;
        if (checkUndefinded === undefined)
            return;
        let validator = passwordsValidator(c, checkUndefinded.label);
        super.setMessage(validator);
        return validator;
    }
};
__decorate([
    ViewChild("passwordConfirm"),
    __metadata("design:type", Object)
], ConfirmPasswordComponent.prototype, "confirm", void 0);
ConfirmPasswordComponent = ConfirmPasswordComponent_1 = __decorate([
    Component({
        selector: "confirm-password",
        templateUrl: "./confirm-password.component.html",
        styleUrls: ["./confirm-password.component.scss"],
        providers: [
            {
                provide: NG_VALUE_ACCESSOR,
                useExisting: forwardRef(() => ConfirmPasswordComponent_1),
                multi: true
            },
            {
                provide: NG_VALIDATORS,
                useExisting: forwardRef(() => ConfirmPasswordComponent_1),
                multi: true
            }
        ]
    }),
    __metadata("design:paramtypes", [])
], ConfirmPasswordComponent);
export { ConfirmPasswordComponent };
var ConfirmPasswordComponent_1;
//# sourceMappingURL=confirm-password.component.js.map