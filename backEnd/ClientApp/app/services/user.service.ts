import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { GlobalVariables } from "../classes/global-variables";

@Injectable()
export class UserService {
  private host = GlobalVariables.host;
  constructor(private _http: HttpClient) {}

  public selectUserById(id: number) {
    return this._http.get(this.host + "api/Posts/Users/" + id);
  }
}
