import {
  Component,
  OnInit,
  Input,
  ViewChild,
  forwardRef,
  ElementRef,
  OnChanges,
  AfterContentChecked
} from "@angular/core";
import { Data } from "../data";
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  Validator,
  NG_VALIDATORS,
  FormControl
} from "@angular/forms";

import { InputField } from "../input-field";
import { emailValidator } from "../../validators/email-validator";

@Component({
  selector: "input-email",
  templateUrl: "../input-text.component.html",
  styleUrls: ["../input-text.component.scss"],

  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputEmailComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => InputEmailComponent),
      multi: true
    }
  ]
})
export class InputEmailComponent extends InputField
  implements ControlValueAccessor, OnChanges {
  constructor() {
    super();
  }

    validate(c: FormControl) {
    const checkUndefinded = this.data;
    if (checkUndefinded === undefined) return;
    let validator = emailValidator(c, checkUndefinded.label);
    super.setMessage(validator);

    return validator;
  }
}
