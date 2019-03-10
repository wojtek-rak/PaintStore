import { LocalStorageService } from "angular-web-storage";
import { StorageData } from "./storage-data";

export abstract class LoginManager {
  private static _userId: number = 0;
  private static _userLoggedIn: boolean = false;
  private static _userToken: string = "";

  private static local: LocalStorageService = new LocalStorageService();

  constructor() {}

  private static checkAuth() {
    if (
      this._userId === 0 &&
      this._userLoggedIn === false &&
      this._userToken === ""
    ) {
      let data = this.local.get(StorageData.getKey());
      if (data === null) {
        this._userLoggedIn = false;
        this._userId = 0;
        this._userToken = "";
      } else {
        this._userId = data.userId;
        this._userToken = data.token;
        this._userLoggedIn = true;
      }
    }
  }

  public static loginUser(data: any) {
    this.local.set(StorageData.getKey(), data);
  }

  public static logoutUser() {
    this.local.remove(StorageData.getKey());
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
}
