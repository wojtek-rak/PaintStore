import { LoginManager } from "./login-manager";
var LoggedIn = /** @class */ (function () {
    function LoggedIn() {
        this._loggedIn = false;
        this._loggedId = 0;
        this._loggedToken = "";
    }
    LoggedIn.prototype.ngOnInit = function () {
        this._loggedIn = LoginManager.userLoggedIn();
        this._loggedId = LoginManager.userId();
        this._loggedToken = LoginManager.userToken();
    };
    Object.defineProperty(LoggedIn.prototype, "loggedIn", {
        get: function () {
            return this._loggedIn;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(LoggedIn.prototype, "loggedId", {
        get: function () {
            return this._loggedId;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(LoggedIn.prototype, "loggedToken", {
        get: function () {
            return this._loggedToken;
        },
        enumerable: true,
        configurable: true
    });
    return LoggedIn;
}());
export { LoggedIn };
//# sourceMappingURL=logged-in.js.map