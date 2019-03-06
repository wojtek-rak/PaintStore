import { FormControl } from "@angular/forms";

export function emailValidator(c: FormControl, fieldName: string) {
  let pattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  if (!c.dirty) {
    return null;
  }

  if (!pattern.test(c.value) || c.value.length === 0) {
    return { error: fieldName + " is wrong." };
  } else {
    return null;
  }
}
