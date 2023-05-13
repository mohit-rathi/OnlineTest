import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

// environment
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  private apiBaseUrl: string = environment.apiBaseUrl;
  public emailRegex: RegExp = /^\w+([\.\-]?\w+)*@\w+([\.\-]?\w+)*(\.\w{2,})+$/;
  public loginError: string | null = null;

  constructor(private http: HttpClient, private router: Router) {}

  public login(data: NgForm): void {
    this.http.post(this.apiBaseUrl + 'auth/login', data).subscribe({
      next: (response: any) => {
        if (response.status == 401) {
          this.loginError = response.error;
        } else {
          const auth = {
            isAuthenticated: true,
            id: response.data.id,
            email: response.data.email,
            token: response.data.token,
          };
          localStorage.setItem('auth', JSON.stringify(auth));
          this.router.navigateByUrl('/dashboard');
        }
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  public dismissAlert() {
    this.loginError = null;
  }
}
