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
import { passwordValidator } from "../../validators/text-validator";
var InputPasswordComponent = /** @class */ (function (_super) {
    __extends(InputPasswordComponent, _super);
    function InputPasswordComponent() {
        return _super.call(this) || this;
    }
    InputPasswordComponent_1 = InputPasswordComponent;
    InputPasswordComponent.prototype.validate = function (c) {
        var validator;
        validator = passwordValidator(c, this.data.label);
        _super.prototype.setMessage.call(this, validator);
        return validator;
    };
    InputPasswordComponent = InputPasswordComponent_1 = __decorate([
        Component({
            selector: "input-password",
            templateUrl: "./input-password.component.html",
            styleUrls: ["../input-text.component.scss"],
            providers: [
                {
                    provide: NG_VALUE_ACCESSOR,
                    useExisting: forwardRef(function () { return InputPasswordComponent_1; }),
                    multi: true
                },
                {
                    provide: NG_VALIDATORS,
                    useExisting: forwardRef(function () { return InputPasswordComponent_1; }),
                    multi: true
                }
            ]
        }),
        __metadata("design:paramtypes", [])
    ], InputPasswordComponent);
    return InputPasswordComponent;
    var InputPasswordComponent_1;
}(InputField));
export { InputPasswordComponent };
//# sourceMappingURL=input-password.component.js.map