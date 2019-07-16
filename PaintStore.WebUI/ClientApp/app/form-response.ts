import { ValidMessage } from "./valid-message";

export class FormResponse {
  constructor(
    private _formOk: boolean,
    public username: ValidMessage,
    public password: ValidMessage,
    public email: ValidMessage,
    public confirmPassword: ValidMessage
  ) {}

  set formOk(formOk: boolean) {
    this._formOk = formOk;
  }

  get formOk() {
    return this._formOk;
  }
}
