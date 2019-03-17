import { LocalStorageService } from "angular-web-storage";
import { GlobalVariables } from "./global-variables";

export abstract class LoginManager {
  private static _userId: number = -1;
  private static _userLoggedIn: boolean = false;
  private static _userToken: string = "";
  private static _imgLink: string = "";

  private static local: LocalStorageService = new LocalStorageService();

  constructor() {}

  private static checkAuth() {
    if (
      this._userId === -1 &&
      this._userLoggedIn === false &&
      this._userToken === ""
    ) {
      let data = this.local.get(GlobalVariables.key);
      if (data === null) {
        this._userLoggedIn = false;
        this._userId = -1;
        this._userToken = "";
      } else {
        this._userId = data.userId;
        this._userToken = data.token;
        this._userLoggedIn = true;
      }
    }
  }

  public static loginUser(data: any) {
    this.local.set(GlobalVariables.key, data);
  }

  public static logoutUser() {
    this.local.remove(GlobalVariables.key);
  }

  public static userId(): number {
    this.checkAuth();
    return this._userId;
  }

  public static userLoggedIn(): boolean {
    this.checkAuth();
    return this._userLoggedIn;
  }

  public static userToken(): string {
    this.checkAuth();
    return this._userToken;
  }

  public static imgLink(): string {
    return this._imgLink;
  }
}
