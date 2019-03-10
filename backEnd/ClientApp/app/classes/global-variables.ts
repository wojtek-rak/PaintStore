export abstract class GlobalVariables {
  private static _key = "id";
  private static _host = "https://paintstorerest.azurewebsites.net/";

  public static get key() {
    return this._key;
  }

  public static get host() {
    return this._host;
  }
}
