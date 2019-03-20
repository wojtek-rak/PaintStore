import { ValidMessage } from "./valid-message";
import { FormResponse } from "./form-response";

export abstract class FormValidationModel {
  private static username = new ValidMessage();
  private static email = new ValidMessage();
  private static password = new ValidMessage();
  private static confirmPassword = new ValidMessage();

  public static validateRegisterForm(
    username: string,
    email: string,
    password: string,
    confirmPassword: string
  ): FormResponse {
    this.validateUsername(username);
    this.validateEmail(email);
    this.validatePassword(password);
    this.validateConfirmation(password, confirmPassword);

    return this.formResponse();
  }

  public static validateLoginForm(username: string, password: string): any {
    let res: { valid: boolean; message: string };
    // check if there is an user with this name and password
    res = {
      valid: true,
      message: ""
    };

    return res;
  }

  private static validateUsername(username: string): void {
    // check if there is an user with this name in database
    if (username === "abc") {
      this.username.setProperties(false, "This name already exist.");
    } else if (username.length < 4) {
      this.username.setProperties(
        false,
        "Username must be at least 4 characters long."
      );
    } else {
      this.username.setProperties(true, "");
    }
  }

  private static validateEmail(email: string): void {
    const pattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!pattern.test(email) || email.length === 0) {
      this.email.setProperties(false, "E-mail is invalid.");
    } else {
      this.email.setProperties(true, "");
    }
  }

  private static validatePassword(password: string): void {
    if (password.length < 4) {
      this.password.setProperties(
        false,
        "Password must be at least 4 characters long."
      );
    } else this.password.setProperties(true, "");
  }

  private static validateConfirmation(
    password: string,
    confirmPassword: string
  ): void {
    if (password !== confirmPassword) {
      this.confirmPassword.setProperties(
        false,
        "Passwords cannot be different."
      );
    } else this.confirmPassword.setProperties(true, "");
  }

  private static isFormOK(): boolean {
    if (this.username.valid === false) {
      return false;
    }
    if (this.email.valid === false) {
      return false;
    }
    if (this.password.valid === false) {
      return false;
    }
    if (this.confirmPassword.valid === false) {
      return false;
    }

    return true;
  }

  public static formResponse(): FormResponse {
    const res = new FormResponse(
      this.isFormOK(),
      this.username,
      this.password,
      this.email,
      this.confirmPassword
    );
    return res;
  }
}
