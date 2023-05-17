import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';

export interface IProfile {
  name: string;
  mobileNo: string;
  email: string;
}

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  public userProfile: IProfile = {} as IProfile;
  public isProfileFetched: boolean = false;

  constructor(
    private _userService: UserService,
    private _authService: AuthService
  ) {}

  ngOnInit(): void {
    this._userService.getUserProfile().subscribe({
      next: (response) => {
        this.userProfile.name = response.data.name;
        this.userProfile.mobileNo = response.data.mobileNo;
        this.userProfile.email = response.data.email;
        this.isProfileFetched = true;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  public logout(): void {
    this._authService.logout();
  }
}
