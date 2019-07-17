import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { GlobalVariables } from "../logic/classes/global-variables";

@Injectable()
export class UserService {
  private host = GlobalVariables.host;
  constructor(private _http: HttpClient) {}

  private getHeaders(id: number, token: string): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.append(
      "Authorization",
      "Basic " + btoa("" + id + ":" + token)
    );
    headers = headers.append("Content-Type", "application/json");

    return headers;
  }

  public selectUserById(id: number) {
    return this._http.get(`${this.host}api/Posts/Users/${id}`);
  }
}
