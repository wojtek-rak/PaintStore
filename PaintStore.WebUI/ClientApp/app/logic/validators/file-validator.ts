import { FormControl } from "@angular/forms";

export function fileValidator(c: FormControl, fieldName: string) {
  const droppedFile = c.value;
  // if file not required
  if (
    droppedFile === "" ||
    droppedFile === null ||
    typeof droppedFile === "undefined" ||
    typeof droppedFile.type === "undefined"
  ) {
    return null;
  }

  // else
  const allowedTypes = ["image/png", "image/jpeg"];
  const allowedExtensions = ["png", "jpg"];

  //TODO
  if (
    !allowedTypes.includes(droppedFile.type) ||
    (droppedFile.type === "" &&
      !allowedExtensions.includes(droppedFile.name.split(".").pop())) ||
    droppedFile.size === 0
  ) {
    return {
      error: "File type is wrong.",
      isNull: false
    };
  }

  if (droppedFile.size / 1024 / 1024 > 4) {
    // 2 MB size
    return {
      error: "File size is too big.",
      isNull: false
    };
  }

  return null;
}
