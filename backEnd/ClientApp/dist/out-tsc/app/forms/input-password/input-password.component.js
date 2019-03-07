var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, forwardRef } from "@angular/core";
import { NG_VALUE_ACCESSOR, NG_VALIDATORS } from "@angular/forms";
import { InputField } from "../input-field";
import { passwordValidator } from "../../validators/text-validator";
let InputPasswordComponent = InputPasswordComponent_1 = class InputPasswordComponent extends InputField {
    constructor() {
        super();
    }
    validate(c) {
        let validator;
        const checkUndefinded = this.data;
        if (checkUndefinded === undefined)
            return;
        validator = passwordValidator(c, checkUndefinded.label);
        super.setMessage(validator);
        return validator;
    }
};
InputPasswordComponent = InputPasswordComponent_1 = __decorate([
    Component({
        selector: "input-password",
        templateUrl: "./input-password.component.html",
        styleUrls: ["../input-text.component.scss"],
        providers: [
            {
                provide: NG_VALUE_ACCESSOR,
                useExisting: forwardRef(() => InputPasswordComponent_1),
                multi: true
            },
            {
                provide: NG_VALIDATORS,
                useExisting: forwardRef(() => InputPasswordComponent_1),
                multi: true
            }
        ]
    }),
    __metadata("design:paramtypes", [])
], InputPasswordComponent);
export { InputPasswordComponent };
var InputPasswordComponent_1;
//# sourceMappingURL=input-password.component.js.map