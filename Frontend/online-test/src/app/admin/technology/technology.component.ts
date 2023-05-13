import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';

// interfaces
import { ITechnology } from '../interfaces/technology.interface';

@Component({
  selector: 'app-technology',
  templateUrl: './technology.component.html',
  styleUrls: ['./technology.component.scss'],
})
export class TechnologyComponent implements OnInit {
  private apiBaseUrl: string = environment.apiBaseUrl;
  public technologyList: ITechnology[] = [];
  public isAdd: boolean = false;
  public isFetching: boolean = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchTechnologies();
  }

  public fetchTechnologies(): void {
    this.isFetching = true;
    this.http.get(this.apiBaseUrl + 'technologies').subscribe({
      next: (response: any) => {
        this.isFetching = false;
        this.technologyList = response.data;
      },
      error: (error) => {
        this.isFetching = false;
        console.log(error);
      },
    });
  }

  public addTechnology(technology: { techName: string }): void {
    this.http.post(this.apiBaseUrl + 'technologies', technology).subscribe({
      next: (response: any) => {
        if (response.status === 201) {
          this.fetchTechnologies();
        }
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  public toggleAddTechnology() {
    this.isAdd = !this.isAdd;
  }
}
