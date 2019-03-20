import { Component, OnInit, forwardRef } from "@angular/core";
import { InputField } from "../input-field";
import { FormControl, NG_VALUE_ACCESSOR, NG_VALIDATORS } from "@angular/forms";
import {
  requiredTextValidator,
  checkboxValidator
} from "ClientApp/app/validators/text-validator";

@Component({
  selector: "input-checkbox",
  templateUrl: "./input-checkbox.component.html",
  styleUrls: ["./input-checkbox.component.scss"],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputCheckboxComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => InputCheckboxComponent),
      multi: true
    }
  ]
})
export class InputCheckboxComponent extends InputField {
  constructor() {
    super();
  }

  validate(c: FormControl) {
    const validator = checkboxValidator(c, "Field");
    super.setMessage(validator);
    return validator;
  }
}
