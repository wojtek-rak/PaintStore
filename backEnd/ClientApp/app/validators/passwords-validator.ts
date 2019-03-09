import { FormControl } from "@angular/forms";

export function passwordsValidator(c: FormControl, fieldName: string) {
  // field is optional
  if (!c.dirty) {
    return null;
  }

  if (c.value === "" || typeof c.value === undefined) return null;
  if (c.value.new === "" && c.value.confirm === "") return null;

  if (c.value === "" || typeof c.value === undefined)
    return {
      error: fieldName + "'s length must be at least 8 characters long."
    };
  if (c.value.new.length < 8)
    return {
      error: fieldName + "'s length must be at least 8 characters long."
    };
  if (c.value.confirm !== c.value.new)
    return { error: fieldName + "s cannot be different." };
  return null;
}
