import { Component, OnInit, OnChanges, forwardRef } from "@angular/core";
import { InputField } from "../input-field";
import {
  FormControl,
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  NG_VALIDATORS
} from "@angular/forms";
import { requiredTextValidator } from "../../validators/text-validator";

@Component({
  selector: "input-option",
  templateUrl: "./input-option.component.html",
  styleUrls: ["./input-option.component.scss"],

  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputOptionComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => InputOptionComponent),
      multi: true
    }
  ]
})
export class InputOptionComponent extends InputField
  implements ControlValueAccessor, OnChanges {
  constructor() {
    super();
  }

  validate(c: FormControl) {
    const checkUndefinded = this.data;
    if (checkUndefinded === undefined) return;
    const validator = requiredTextValidator(c, checkUndefinded.label);
    super.setMessage(validator);

    return validator;
  }
}
