import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';

// interfaces
import { ITest } from '../interfaces/test.interface';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss'],
})
export class TestComponent implements OnInit {
  private apiBaseUrl: string = environment.apiBaseUrl;
  public testList: ITest[] = [];
  public isAdd: boolean = false;
  public isFetching: boolean = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchTests();
  }

  public fetchTests(): void {
    this.isFetching = true;
    this.http.get(this.apiBaseUrl + 'tests').subscribe({
      next: (response: any) => {
        this.isFetching = false;
        this.testList = response.data;
      },
      error: (error) => {
        this.isFetching = false;
        console.log(error);
      },
    });
  }

  public addTest(test: { testName: string }): void {
    this.http.post(this.apiBaseUrl + 'technologies', test).subscribe({
      next: (response: any) => {
        if (response.status === 201) {
          this.fetchTests();
        }
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  public toggleAddTest() {
    this.isAdd = !this.isAdd;
  }
}
