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
import { NG_VALUE_ACCESSOR } from "@angular/forms";
import { InputField } from "../input-field";
// import { textValidator } from "../../validators/text-validator";
let TextareaComponent = TextareaComponent_1 = class TextareaComponent extends InputField {
    constructor() {
        super();
    }
    validate(c) {
        // let validator = textValidator(c, this.data.label);
        // super.setMessage(validator);
        return null;
    }
};
TextareaComponent = TextareaComponent_1 = __decorate([
    Component({
        selector: "input-textarea",
        templateUrl: "./textarea.component.html",
        styleUrls: ["./textarea.component.scss"],
        providers: [
            {
                provide: NG_VALUE_ACCESSOR,
                useExisting: forwardRef(() => TextareaComponent_1),
                multi: true
            }
            // {
            //   provide: NG_VALIDATORS,
            //   useExisting: forwardRef(() => TextareaComponent),
            //   multi: true
            // }
        ]
    }),
    __metadata("design:paramtypes", [])
], TextareaComponent);
export { TextareaComponent };
var TextareaComponent_1;
//# sourceMappingURL=textarea.component.js.map