import { Component, OnDestroy, OnInit } from '@angular/core';

// interfaces
import { ITest } from '../interfaces/test.interface';

// services
import { TestService } from 'src/app/services/test.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss'],
})
export class TestComponent implements OnInit, OnDestroy {
  public testId!: string;
  public testList: ITest[] = [];
  public isAdd: boolean = false;
  public isFetching: boolean = false;
  public paramsSubscription!: Subscription;

  constructor(
    private _testService: TestService,
    private _activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.paramsSubscription = this._activatedRoute.params.subscribe({
      next: (params) => {
        this.testId = params['testId'];
        this.fetchTests(this.testId);
      },
    });
  }

  ngOnDestroy(): void {
    this.paramsSubscription.unsubscribe();
  }

  public fetchTests(id: string): void {
    this.isFetching = true;
    this._testService.getTests(id).subscribe({
      next: (response: any) => {
        this.isFetching = false;
        console.log(response.data);

        // this.testList = response.data;
      },
      error: (error) => {
        this.isFetching = false;
        console.log(error);
      },
    });
  }

  public addTest(test: { testName: string }): void {
    this._testService.addTest(test).subscribe({
      next: (response: any) => {
        if (response.status === 201) {
          // this.fetchTests();
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
