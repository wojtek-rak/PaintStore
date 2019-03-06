export function fileValidator(c, fieldName) {
    var droppedFile = c.value;
    // if file not required
    if (droppedFile === "" ||
        droppedFile === null ||
        typeof droppedFile === "undefined" ||
        typeof droppedFile.type === "undefined")
        return null;
    // else
    var allowedTypes = ["image/png", "image/jpeg"];
    var allowedExtensions = ["png", "jpg"];
    if (!allowedTypes.includes(droppedFile.type) ||
        (droppedFile.type === "" &&
            !allowedExtensions.includes(droppedFile.name.split(".").pop())) ||
        droppedFile.size === 0) {
        return {
            error: fieldName + " type is wrong."
        };
    }
    if (droppedFile.size / 1024 / 1024 > 4) {
        // 2 MB size
        return {
            error: fieldName + " size is too big."
        };
    }
    return null;
}
//# sourceMappingURL=file-validator.js.map