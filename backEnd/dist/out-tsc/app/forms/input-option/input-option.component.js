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
import { InputField } from "../input-field";
import { NG_VALUE_ACCESSOR, NG_VALIDATORS } from "@angular/forms";
import { requiredTextValidator } from "../../validators/text-validator";
let InputOptionComponent = InputOptionComponent_1 = class InputOptionComponent extends InputField {
    constructor() {
        super();
    }
    validate(c) {
        const checkUndefinded = this.data;
        if (checkUndefinded === undefined)
            return;
        let validator = requiredTextValidator(c, checkUndefinded.label);
        super.setMessage(validator);
        return validator;
    }
};
InputOptionComponent = InputOptionComponent_1 = __decorate([
    Component({
        selector: "input-option",
        templateUrl: "./input-option.component.html",
        styleUrls: ["./input-option.component.scss"],
        providers: [
            {
                provide: NG_VALUE_ACCESSOR,
                useExisting: forwardRef(() => InputOptionComponent_1),
                multi: true
            },
            {
                provide: NG_VALIDATORS,
                useExisting: forwardRef(() => InputOptionComponent_1),
                multi: true
            }
        ]
    }),
    __metadata("design:paramtypes", [])
], InputOptionComponent);
export { InputOptionComponent };
var InputOptionComponent_1;
//# sourceMappingURL=input-option.component.js.map