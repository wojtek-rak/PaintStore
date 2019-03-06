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
import { requiredTextValidator } from "../../validators/text-validator";
import { shortTextValidator } from "../../validators/text-validator";
let InputTextComponent = InputTextComponent_1 = class InputTextComponent extends InputField {
    constructor() {
        super();
    }
    validate(c) {
        let validator;
        const checkUndefinded = this.data;
        if (checkUndefinded === undefined)
            return;
        if (checkUndefinded.validation === "short") {
            validator = shortTextValidator(c, checkUndefinded.label);
        }
        else {
            validator = requiredTextValidator(c, checkUndefinded.label);
        }
        super.setMessage(validator);
        return validator;
    }
};
InputTextComponent = InputTextComponent_1 = __decorate([
    Component({
        selector: "input-text",
        templateUrl: "../input-text.component.html",
        styleUrls: ["../input-text.component.scss"],
        providers: [
            {
                provide: NG_VALUE_ACCESSOR,
                useExisting: forwardRef(() => InputTextComponent_1),
                multi: true
            },
            {
                provide: NG_VALIDATORS,
                useExisting: forwardRef(() => InputTextComponent_1),
                multi: true
            }
        ]
    }),
    __metadata("design:paramtypes", [])
], InputTextComponent);
export { InputTextComponent };
var InputTextComponent_1;
//# sourceMappingURL=input-text.component.js.map