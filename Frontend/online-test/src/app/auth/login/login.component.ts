import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  public emailRegex: RegExp = /^\w+([\.\-]?\w+)*@\w+([\.\-]?\w+)*(\.\w{2,})+$/;
  public loginError: string | null = null;

  constructor(private _authService: AuthService, private router: Router) {}

  public login(formData: NgForm): void {
    const data = formData.value;
    this._authService.login(data).subscribe({
      next: (response: any) => {
        if (response.status == 401) {
          this.loginError = response.error;
        } else {
          const auth = {
            id: response.data.id,
            email: response.data.email,
            token: response.data.token,
          };
          localStorage.setItem('auth', JSON.stringify(auth));
          this.router.navigateByUrl('/dashboard');
        }
      },
      error: (error) => {
        // console.log(error);
        this.loginError = 'Some error occurred.';
      },
    });
  }

  public dismissAlert() {
    this.loginError = null;
  }
}
