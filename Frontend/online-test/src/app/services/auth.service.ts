import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

// environment
import { environment as env } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _url: string = env.apiBaseUrl + 'auth/';

  constructor(private _http: HttpClient, private _router: Router) {}

  public login(data: { email: string; password: string }): Observable<any> {
    return this._http.post(this._url + 'login', data);
  }

  public logout(): void {
    localStorage.removeItem('auth');
    this._router.navigate(['auth', 'login']);
  }
}
