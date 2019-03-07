export function shortTextValidator(c, fieldName) {
    if (!c.dirty) {
        return null;
    }
    return c.value.length > 90
        ? { error: fieldName + " cannot be more than 90 characters long." }
        : null;
}
export function requiredTextValidator(c, fieldName) {
    if (!c.dirty) {
        return null;
    }
    return c.value.length < 4
        ? { error: fieldName + " must be at least 4 characters long." }
        : null;
}
export function passwordValidator(c, fieldName) {
    if (!c.dirty) {
        return null;
    }
    return c.value.length < 8
        ? { error: fieldName + " must be at least 8 characters long." }
        : null;
}
//# sourceMappingURL=text-validator.js.map