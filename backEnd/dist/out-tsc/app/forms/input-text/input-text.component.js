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
import { Component, forwardRef } from "@angular/core";
import { NG_VALUE_ACCESSOR, NG_VALIDATORS } from "@angular/forms";
import { InputField } from "../input-field";
import { requiredTextValidator } from "../../validators/text-validator";
import { shortTextValidator } from "../../validators/text-validator";
var InputTextComponent = /** @class */ (function (_super) {
    __extends(InputTextComponent, _super);
    function InputTextComponent() {
        return _super.call(this) || this;
    }
    InputTextComponent_1 = InputTextComponent;
    InputTextComponent.prototype.validate = function (c) {
        var validator;
        var checkUndefinded = this.data;
        if (checkUndefinded === undefined)
            return;
        if (checkUndefinded.validation === "short") {
            validator = shortTextValidator(c, checkUndefinded.label);
        }
        else {
            validator = requiredTextValidator(c, checkUndefinded.label);
        }
        _super.prototype.setMessage.call(this, validator);
        return validator;
    };
    InputTextComponent = InputTextComponent_1 = __decorate([
        Component({
            selector: "input-text",
            templateUrl: "../input-text.component.html",
            styleUrls: ["../input-text.component.scss"],
            providers: [
                {
                    provide: NG_VALUE_ACCESSOR,
                    useExisting: forwardRef(function () { return InputTextComponent_1; }),
                    multi: true
                },
                {
                    provide: NG_VALIDATORS,
                    useExisting: forwardRef(function () { return InputTextComponent_1; }),
                    multi: true
                }
            ]
        }),
        __metadata("design:paramtypes", [])
    ], InputTextComponent);
    return InputTextComponent;
    var InputTextComponent_1;
}(InputField));
export { InputTextComponent };
//# sourceMappingURL=input-text.component.js.map