var ValidateFileForm = /** @class */ (function () {
    function ValidateFileForm() {
        this._title = "";
        this._category = "";
        this._file = "";
    }
    Object.defineProperty(ValidateFileForm.prototype, "title", {
        get: function () {
            return this._title;
        },
        set: function (title) {
            this._title = title;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ValidateFileForm.prototype, "file", {
        get: function () {
            return this._file;
        },
        set: function (file) {
            this._file = file;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ValidateFileForm.prototype, "category", {
        get: function () {
            return this._category;
        },
        set: function (category) {
            this._category = category;
        },
        enumerable: true,
        configurable: true
    });
    return ValidateFileForm;
}());
export { ValidateFileForm };
//# sourceMappingURL=validate-file-form.js.map