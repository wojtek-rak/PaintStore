var FormResponse = /** @class */ (function () {
    function FormResponse(_formOk, username, password, email, confirmPassword) {
        this._formOk = _formOk;
        this.username = username;
        this.password = password;
        this.email = email;
        this.confirmPassword = confirmPassword;
    }
    Object.defineProperty(FormResponse.prototype, "formOk", {
        get: function () {
            return this._formOk;
        },
        set: function (formOk) {
            this._formOk = formOk;
        },
        enumerable: true,
        configurable: true
    });
    return FormResponse;
}());
export { FormResponse };
//# sourceMappingURL=form-response.js.map