import { LocalStorageService } from "angular-web-storage";
import { StorageData } from "./storage-data";
export class LoginManager {
    constructor() { }
    static checkAuth() {
        if (this._userId === null &&
            this._userLoggedIn === null &&
            this._userToken === null) {
            let data = this.local.get(StorageData.getKey());
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
    }
    static loginUser(data) {
        this.local.set(StorageData.getKey(), data);
    }
    static logoutUser() {
        this.local.remove(StorageData.getKey());
    }
    static userId() {
        this.checkAuth();
        return this._userId;
    }
    static userLoggedIn() {
        this.checkAuth();
        return this._userLoggedIn;
    }
    static userToken() {
        this.checkAuth();
        return this._userToken;
    }
}
LoginManager._userId = 0; // TODO CHANGE FROM NULL
LoginManager._userLoggedIn = false; // TODO CHANGE FROM NULL
LoginManager._userToken = ""; // TODO CHANGE FROM NULL
LoginManager.local = new LocalStorageService();
//# sourceMappingURL=login-manager.js.map