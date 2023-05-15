import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

// environment
import { environment as env } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class TechnologyService {
  private _baseUrl: string = env.apiBaseUrl + 'technologies/';
  constructor(private _http: HttpClient) {}

  public getTechnologies(): Observable<any> {
    return this._http.get(this._baseUrl);
  }

  public addTechnology(technology: { techName: string }): Observable<any> {
    return this._http.post(this._baseUrl, technology);
  }
}
