import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { GlobalVariables } from "../logic/classes/global-variables";

@Injectable({
  providedIn: "root"
})
export class AccountService {
  private host = GlobalVariables.host;
  constructor(private _http: HttpClient) {}

  public selectUserById(id: number) {
    return this._http.get(this.host + "api/Posts/Users/" + id);
  }

  getUserToken(data: any) {
    return this._http.post(this.host + "api/SignIn/In", data);
  }

  registerUser(data: any) {
    return this._http.post(this.host + "api/Users/AddUser", data);
  }

  logoutUser(data: any, id: number, token: string) {
    let headers = new HttpHeaders();
    headers = headers.append(
      "Authorization",
      "Basic " + btoa("" + id + ":" + token)
    );
    headers = headers.append("Content-Type", "application/json");
    return this._http.post(this.host + "api/SignIn/Out", data, {
      headers: headers
    });
  }
}
