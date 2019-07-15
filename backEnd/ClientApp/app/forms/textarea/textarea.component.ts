import {
  Component,
  OnInit,
  Input,
  ViewChild,
  ElementRef,
  forwardRef
} from "@angular/core";
import { Data } from "../data";
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  FormControl,
  NG_VALIDATORS
} from "@angular/forms";
import { InputField } from "../input-field";
import { requiredTextareaValidator } from "ClientApp/app/logic/validators/text-validator";
// import { textValidator } from "../../validators/text-validator";

@Component({
  selector: "input-textarea",
  templateUrl: "./textarea.component.html",
  styleUrls: ["./textarea.component.scss"],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => TextareaComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => TextareaComponent),
      multi: true
    }
  ]
})
export class TextareaComponent extends InputField {
  constructor() {
    super();
  }

  validate(c: FormControl) {
    if (this.data.validation === "required") {
      // let validator = textValidator(c, this.data.label);
      // super.setMessage(validator);
      let validator = requiredTextareaValidator(c, this.data.label);
      super.setMessage(validator);
      return validator;
    }
    return null;
  }
}
