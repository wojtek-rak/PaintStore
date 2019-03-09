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

import { Data } from "./data";
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  Validator,
  NG_VALIDATORS,
  FormControl
} from "@angular/forms";

export abstract class InputField implements OnChanges, ControlValueAccessor {
  protected _validateMessage: string;
  editing: boolean = false;
  @Input() data?: Data = undefined;
  @ViewChild("input") Input?: ElementRef = undefined;

  constructor() {
    this._validateMessage = "";
  }

  public abstract validate(param : any): void;

  setMessage(validator : any) {
    // if there is an error
    if (validator !== null) {
      this._validateMessage = validator.error;
    } else {
      this._validateMessage = "";
    }
  }

  // allow to choose if edit fields are visible
  startEditing() {
    this.editing = true;
  }

    stopEditing() {
    const checkUndefinded = this.Input;
    if (checkUndefinded === undefined) return;
    checkUndefinded.nativeElement.value = "";
    this.propagateChange("");
    this.editing = false;
  }

  // to not show error when first validate empty field
    ngOnChanges() {
        const checkUndefinded = this.Input;
        if (checkUndefinded === undefined) return;
        this.propagateChange(checkUndefinded.nativeElement.value);
  }

  // Control Value Accessor Implementation
  propagateChange = (_: any) => {};

  writeValue(value: string) {
      if (value !== undefined) {
          const checkUndefinded = this.Input;
          if (checkUndefinded === undefined) return;
          checkUndefinded.nativeElement.value = value;
    }
  }

  registerOnChange(fn : any) {
    this.propagateChange = fn;
  }

  registerOnTouched() {}

  change(value : any) {
    this.propagateChange(value);
  }

  // getters
  get validateMessage() {
    return this._validateMessage;
  }
}
