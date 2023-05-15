import { Component, OnInit } from '@angular/core';

// interfaces
import { ITechnology } from '../interfaces/technology.interface';
import { TechnologyService } from 'src/app/services/technology.service';

@Component({
  selector: 'app-technology',
  templateUrl: './technology.component.html',
  styleUrls: ['./technology.component.scss'],
})
export class TechnologyComponent implements OnInit {
  public technologyList: ITechnology[] = [];
  public isAdd: boolean = false;
  public isFetching: boolean = false;

  constructor(private _technologyService: TechnologyService) {}

  ngOnInit(): void {
    this.fetchTechnologies();
  }

  public fetchTechnologies(): void {
    this.isFetching = true;
    this._technologyService.getTechnologies().subscribe({
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
    this._technologyService.addTechnology(technology).subscribe({
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
