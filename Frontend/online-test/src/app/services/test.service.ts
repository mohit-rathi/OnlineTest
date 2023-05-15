import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

// environment
import { environment as env } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class TestService {
  private _url = env.apiBaseUrl + 'tests/';

  constructor(private _http: HttpClient) {}

  public getTests(id: string): Observable<any> {
    return this._http.get(this._url, {
      params: {
        id: id,
      },
    });
  }

  public addTest(test: any): Observable<any> {
    return this._http.post(this._url, test);
  }
}
