import { LoginManager } from "./login-manager";
export class LoggedIn {
    constructor() {
        this._loggedIn = false;
        this._loggedId = 0;
        this._loggedToken = "";
    }
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
//# sourceMappingURL=logged-in.js.map