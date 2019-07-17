export class ValidMessage {
  private _valid: boolean;
  private _message: string;

  constructor() {
    this._valid = true;
    this._message = "";
  }

  public setProperties(valid: boolean, message: string): void {
    this._valid = valid;
    this._message = message;
  }

  get valid(): boolean {
    return this._valid;
  }

  get message(): string {
    return this._message;
  }
}
