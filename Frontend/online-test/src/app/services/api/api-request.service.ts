import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';

// interfaces
import { IResponse } from 'src/app/admin/interfaces/response.interface';

@Injectable({
  providedIn: 'root',
})
export class ApiRequestService {
  apiBaseUrl: string = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  public get(apiUrl: string, token: string): Observable<IResponse> {
    return this.http.get<IResponse>(this.apiBaseUrl + apiUrl, {
      headers: new HttpHeaders().set('Authorization', token),
    });
  }

  public put(apiUrl: string, token: string, data: any): Observable<IResponse> {
    return this.http.put<IResponse>(this.apiBaseUrl + apiUrl, data, {
      headers: new HttpHeaders().set('Authorization', token),
    });
  }

  public post(apiUrl: string, token: string, data: any): Observable<IResponse> {
    return this.http.post<IResponse>(this.apiBaseUrl + apiUrl, data, {
      headers: new HttpHeaders().set('Authorization', token),
    });
  }

  public delete(apiUrl: string, token: string): Observable<IResponse> {
    return this.http.delete<IResponse>(this.apiBaseUrl + apiUrl, {
      headers: new HttpHeaders().set('Authorization', token),
    });
  }
}
