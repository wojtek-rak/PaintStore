import { Component, forwardRef, ViewChild, OnInit } from "@angular/core";
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  NG_VALIDATORS,
  FormControl
} from "@angular/forms";
import { InputField } from "../input-field";
import { passwordsValidator } from "../../logic/validators/passwords-validator";

@Component({
  selector: "confirm-password",
  templateUrl: "./confirm-password.component.html",
  styleUrls: ["./confirm-password.component.scss"],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ConfirmPasswordComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => ConfirmPasswordComponent),
      multi: true
    }
  ]
})
export class ConfirmPasswordComponent extends InputField {
  @ViewChild("passwordConfirm") confirm: any;
  constructor() {
    super();
  }

  stopEditing() {
    this.confirm.nativeElement.value = "";
    super.stopEditing();
  }

  validate(c: FormControl) {
    const checkUndefinded = this.data;
    if (checkUndefinded === undefined) {
      return;
    }

    const validator = passwordsValidator(c, checkUndefinded.label);
    super.setMessage(validator);
    return validator;
  }
}
