import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class UserService {
  private host = "http://paintstorerest.azurewebsites.net/";
  constructor(private _http: HttpClient) {}

  public selectUserById(id: number) {
    return this._http.get(this.host + "api/Posts/Users/" + id);
  }
}
