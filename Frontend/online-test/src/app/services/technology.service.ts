import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

// environment
import { environment as env } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class TechnologyService {
  private _url: string = env.apiBaseUrl + 'technologies/';
  constructor(private _http: HttpClient) {}

  public getTechnologies(): Observable<any> {
    return this._http.get(this._url);
  }

  public addTechnology(technology: { techName: string }): Observable<any> {
    return this._http.post(this._url, technology);
  }

  public updateTechnology(technology: {
    id: number;
    techName: string;
  }): Observable<any> {
    return this._http.put(this._url, technology);
  }

  public deleteTechnology(id: number): Observable<any> {
    return this._http.delete(this._url, { params: { id: id } });
  }
}
