import { LoginManager } from "./login-manager";
import { OnInit } from "@angular/core";

export class LoggedIn implements OnInit {
  protected _loggedIn = false;
  protected _loggedId = 0;
  protected _loggedToken = "";

  ngOnInit() {
    this._loggedIn = LoginManager.userLoggedIn();
    this._loggedId = LoginManager.userId();
    this._loggedToken = LoginManager.userToken();
  }

  get loggedIn() {
    return this._loggedIn;
  }

  get loggedId() {
    return this._loggedId;
  }

  get loggedToken() {
    return this._loggedToken;
  }
}
