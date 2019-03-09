import { LocalStorageService } from "angular-web-storage";
import { StorageData } from "./storage-data";
var LoginManager = /** @class */ (function () {
    function LoginManager() {
    }
    LoginManager.checkAuth = function () {
        if (this._userId === null &&
            this._userLoggedIn === null &&
            this._userToken === null) {
            var data = this.local.get(StorageData.getKey());
            console.log(data);
            if (data === null) {
                this._userLoggedIn = false;
                this._userId = 0;
                this._userToken = "";
            }
            else {
                this._userId = data.userId;
                this._userToken = data.token;
                this._userLoggedIn = true;
            }
        }
    };
    LoginManager.loginUser = function (data) {
        this.local.set(StorageData.getKey(), data);
    };
    LoginManager.logoutUser = function () {
        this.local.remove(StorageData.getKey());
    };
    LoginManager.userId = function () {
        this.checkAuth();
        return this._userId;
    };
    LoginManager.userLoggedIn = function () {
        this.checkAuth();
        return this._userLoggedIn;
    };
    LoginManager.userToken = function () {
        this.checkAuth();
        return this._userToken;
    };
    LoginManager._userId = null;
    LoginManager._userLoggedIn = null;
    LoginManager._userToken = null;
    LoginManager.local = new LocalStorageService();
    return LoginManager;
}());
export { LoginManager };
//# sourceMappingURL=login-manager.js.map