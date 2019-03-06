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
export class InputField {
    constructor() {
        this.editing = false;
        this.data = undefined;
        this.Input = undefined;
        // Control Value Accessor Implementation
        this.propagateChange = (_) => { };
        this._validateMessage = "";
    }
    setMessage(validator) {
        // if there is an error
        if (validator !== null) {
            this._validateMessage = validator.error;
        }
        else {
            this._validateMessage = "";
        }
    }
    // allow to choose if edit fields are visible
    startEditing() {
        this.editing = true;
    }
    stopEditing() {
        const checkUndefinded = this.Input;
        if (checkUndefinded === undefined)
            return;
        checkUndefinded.nativeElement.value = "";
        this.propagateChange("");
        this.editing = false;
    }
    // to not show error when first validate empty field
    ngOnChanges() {
        const checkUndefinded = this.Input;
        if (checkUndefinded === undefined)
            return;
        this.propagateChange(checkUndefinded.nativeElement.value);
    }
    writeValue(value) {
        if (value !== undefined) {
            const checkUndefinded = this.Input;
            if (checkUndefinded === undefined)
                return;
            checkUndefinded.nativeElement.value = value;
        }
    }
    registerOnChange(fn) {
        this.propagateChange = fn;
    }
    registerOnTouched() { }
    change(value) {
        this.propagateChange(value);
    }
    // getters
    get validateMessage() {
        return this._validateMessage;
    }
}
__decorate([
    Input(),
    __metadata("design:type", Object)
], InputField.prototype, "data", void 0);
__decorate([
    ViewChild("input"),
    __metadata("design:type", ElementRef)
], InputField.prototype, "Input", void 0);
//# sourceMappingURL=input-field.js.map