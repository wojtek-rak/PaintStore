var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Input, ViewChild, ElementRef } from "@angular/core";
var InputField = /** @class */ (function () {
    function InputField() {
        this.editing = false;
        // Control Value Accessor Implementation
        this.propagateChange = function (_) { };
        this._validateMessage = "";
    }
    InputField.prototype.setMessage = function (validator) {
        // if there is an error
        if (validator !== null) {
            this._validateMessage = validator.error;
        }
        else {
            this._validateMessage = "";
        }
    };
    // allow to choose if edit fields are visible
    InputField.prototype.startEditing = function () {
        this.editing = true;
    };
    InputField.prototype.stopEditing = function () {
        this.Input.nativeElement.value = "";
        this.propagateChange("");
        this.editing = false;
    };
    // to not show error when first validate empty field
    InputField.prototype.ngOnChanges = function () {
        this.propagateChange(this.Input.nativeElement.value);
    };
    InputField.prototype.writeValue = function (value) {
        if (value !== undefined) {
            this.Input.nativeElement.value = value;
        }
    };
    InputField.prototype.registerOnChange = function (fn) {
        this.propagateChange = fn;
    };
    InputField.prototype.registerOnTouched = function () { };
    InputField.prototype.change = function (value) {
        this.propagateChange(value);
    };
    Object.defineProperty(InputField.prototype, "validateMessage", {
        // getters
        get: function () {
            return this._validateMessage;
        },
        enumerable: true,
        configurable: true
    });
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], InputField.prototype, "data", void 0);
    __decorate([
        ViewChild("input"),
        __metadata("design:type", typeof (_a = typeof ElementRef !== "undefined" && ElementRef) === "function" && _a || Object)
    ], InputField.prototype, "Input", void 0);
    return InputField;
    var _a;
}());
export { InputField };
//# sourceMappingURL=input-field.js.map