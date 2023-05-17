import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// environment
import { environment as env } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private _url: string = env.apiBaseUrl + 'users/';

  constructor(private _http: HttpClient) {}

  public getUserProfile(): Observable<any> {
    return this._http.get(this._url + 'profile');
  }
}
