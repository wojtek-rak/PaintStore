export class FormResponse {
    constructor(_formOk, username, password, email, confirmPassword) {
        this._formOk = _formOk;
        this.username = username;
        this.password = password;
        this.email = email;
        this.confirmPassword = confirmPassword;
    }
    set formOk(formOk) {
        this._formOk = formOk;
    }
    get formOk() {
        return this._formOk;
    }
}
//# sourceMappingURL=form-response.js.map