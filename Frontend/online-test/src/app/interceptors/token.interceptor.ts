import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const auth = localStorage.getItem('auth');
    if (auth) {
      const user = JSON.parse(auth);
      const token = user['token'];
      const req = request.clone({
        headers: request.headers.append('Authorization', `Bearer ${token}`),
      });
      request = req;
    }
    return next.handle(request);
  }
}
