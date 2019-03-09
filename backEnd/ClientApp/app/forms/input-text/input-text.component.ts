import { Component, forwardRef } from "@angular/core";
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  NG_VALIDATORS,
  FormControl
} from "@angular/forms";
import { InputField } from "../input-field";
import { requiredTextValidator } from "../../validators/text-validator";
import { shortTextValidator } from "../../validators/text-validator";

@Component({
  selector: "input-text",
  templateUrl: "../input-text.component.html",
  styleUrls: ["../input-text.component.scss"],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputTextComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => InputTextComponent),
      multi: true
    }
  ]
})
export class InputTextComponent extends InputField {
  constructor() {
    super();
  }

  validate(c: FormControl) {
      let validator;

      const checkUndefinded = this.data;
      if (checkUndefinded === undefined) return;
      if (checkUndefinded.validation === "short") {
          validator = shortTextValidator(c, checkUndefinded.label);
    } else {
          validator = requiredTextValidator(c, checkUndefinded.label);
    }
    super.setMessage(validator);
    return validator;
  }
}
