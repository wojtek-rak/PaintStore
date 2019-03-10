import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class UserService {
  private host = "https://localhost:5000/";
  constructor(private _http: HttpClient) {}

  public selectUserById(id: number) {
    return this._http.get(this.host + "api/Posts/Users/" + id);
  }
}
