import { FormControl } from "@angular/forms";

export function checkboxValidator(c: FormControl, fieldName: string) {
  // do not show error if the form was not touched
  if (!c.dirty) {
    return null;
  }

  return c.value === false ? { error: fieldName + " must be selected." } : null;
}

export function shortTextValidator(c: FormControl, fieldName: string) {
  if (!c.dirty) {
    return null;
  }

  return c.value.length > 90
    ? { error: fieldName + " cannot be more than 90 characters long." }
    : null;
}

export function requiredTextValidator(c: FormControl, fieldName: string) {
  if (!c.dirty) {
    return null;
  }

  return c.value.length < 4
    ? { error: fieldName + " must be at least 4 characters long." }
    : null;
}

export function requiredTextareaValidator(c: FormControl, fieldName: string) {
  if (!c.dirty) {
    return null;
  }
  // console.log("tutaj c", c);

  return c.value.length < 1
    ? { error: (fieldName === "" ? "Field" : fieldName) + " must be filled." }
    : null;
}

export function passwordValidator(c: FormControl, fieldName: string) {
  if (!c.dirty) {
    return null;
  }

  return c.value.length < 8
    ? { error: fieldName + " must be at least 8 characters long." }
    : null;
}
