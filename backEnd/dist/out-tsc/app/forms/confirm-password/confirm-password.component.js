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
import { Component, forwardRef, ViewChild } from "@angular/core";
import { NG_VALUE_ACCESSOR, NG_VALIDATORS } from "@angular/forms";
import { InputField } from "../input-field";
import { passwordsValidator } from "../../validators/passwords-validator";
var ConfirmPasswordComponent = /** @class */ (function (_super) {
    __extends(ConfirmPasswordComponent, _super);
    function ConfirmPasswordComponent() {
        return _super.call(this) || this;
    }
    ConfirmPasswordComponent_1 = ConfirmPasswordComponent;
    ConfirmPasswordComponent.prototype.stopEditing = function () {
        this.confirm.nativeElement.value = "";
        _super.prototype.stopEditing.call(this);
    };
    ConfirmPasswordComponent.prototype.validate = function (c) {
        var checkUndefinded = this.data;
        if (checkUndefinded === undefined)
            return;
        var validator = passwordsValidator(c, checkUndefinded.label);
        _super.prototype.setMessage.call(this, validator);
        return validator;
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
                    useExisting: forwardRef(function () { return ConfirmPasswordComponent_1; }),
                    multi: true
                },
                {
                    provide: NG_VALIDATORS,
                    useExisting: forwardRef(function () { return ConfirmPasswordComponent_1; }),
                    multi: true
                }
            ]
        }),
        __metadata("design:paramtypes", [])
    ], ConfirmPasswordComponent);
    return ConfirmPasswordComponent;
    var ConfirmPasswordComponent_1;
}(InputField));
export { ConfirmPasswordComponent };
//# sourceMappingURL=confirm-password.component.js.map