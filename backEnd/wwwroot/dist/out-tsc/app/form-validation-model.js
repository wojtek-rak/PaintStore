import { ValidMessage } from "./valid-message";
import { FormResponse } from "./form-response";
export class FormValidationModel {
    static validateRegisterForm(username, email, password, confirmPassword) {
        this.validateUsername(username);
        this.validateEmail(email);
        this.validatePassword(password);
        this.validateConfirmation(password, confirmPassword);
        return this.formResponse();
    }
    static validateLoginForm(username, password) {
        let res;
        // if (username === password) {
        // check if there is an user with this name and password
        res = {
            valid: true,
            message: ""
        };
        // } else {
        //   res = {
        //     valid: false,
        //     message: "User with given name and password cannot be found."
        //   };
        // }
        return res;
    }
    static validateUsername(username) {
        // check if there is an user with this name in database
        if (username === "abc") {
            this.username.setProperties(false, "This name already exist.");
        }
        else if (username.length < 4) {
            this.username.setProperties(false, "Username must be at least 4 characters long.");
        }
        else {
            this.username.setProperties(true, "");
        }
    }
    static validateEmail(email) {
        let pattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!pattern.test(email) || email.length === 0) {
            this.email.setProperties(false, "E-mail is invalid.");
        }
        else {
            this.email.setProperties(true, "");
        }
    }
    static validatePassword(password) {
        if (password.length < 4) {
            this.password.setProperties(false, "Password must be at least 4 characters long.");
        }
        else
            this.password.setProperties(true, "");
    }
    static validateConfirmation(password, confirmPassword) {
        if (password !== confirmPassword) {
            this.confirmPassword.setProperties(false, "Passwords cannot be different.");
        }
        else
            this.confirmPassword.setProperties(true, "");
    }
    static isFormOK() {
        if (this.username.valid === false)
            return false;
        if (this.email.valid === false)
            return false;
        if (this.password.valid === false)
            return false;
        if (this.confirmPassword.valid === false)
            return false;
        return true;
    }
    static formResponse() {
        let res = new FormResponse(this.isFormOK(), this.username, this.password, this.email, this.confirmPassword);
        return res;
    }
}
FormValidationModel.username = new ValidMessage();
FormValidationModel.email = new ValidMessage();
FormValidationModel.password = new ValidMessage();
FormValidationModel.confirmPassword = new ValidMessage();
//# sourceMappingURL=form-validation-model.js.map