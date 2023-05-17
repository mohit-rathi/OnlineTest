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
  public updateTech: { id: number; techName: string } | undefined;
  public error: string | undefined;
  public success: string | undefined;

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
        // console.log(error);
        this.error = 'Some error occurred, could not fetch technologies.';
      },
    });
  }

  public addTechnology(technology: { techName: string }): void {
    this._technologyService.addTechnology(technology).subscribe({
      next: (response: any) => {
        if (response.status === 201) {
          this.fetchTechnologies();
          this.success = 'Technology added successfuly.';
          this.error = undefined;
        } else if (response.status === 400) {
          this.error = response.error;
          this.success = undefined;
        }
      },
      error: (error) => {
        // console.log(error);
        this.error = 'Some error occurred, could not add technology.';
        this.success = undefined;
      },
    });
  }

  public updateTechnology(technology: { id: number; techName: string }): void {
    this._technologyService.updateTechnology(technology).subscribe({
      next: (response: any) => {
        if (response.status === 204) {
          this.updateTech = undefined;
          this.hideAddTechnology();
          this.fetchTechnologies();
          this.success = 'Technology updated successfuly.';
          this.error = undefined;
        } else if (response.status === 400) {
          this.error = response.error;
          this.success = undefined;
        }
      },
      error: (error) => {
        // console.log(error);
        this.error = 'Some error occurred, could not update technology.';
        this.success = undefined;
      },
    });
  }

  public deleteTechnology(id: number): void {
    this._technologyService.deleteTechnology(id).subscribe({
      next: (response: any) => {
        if (response.status === 204) {
          this.fetchTechnologies();
          this.success = 'Technology deleted successfuly.';
          this.error = undefined;
        } else if (response.status === 400) {
          this.error = response.error;
          this.success = undefined;
        }
      },
      error: (error) => {
        // console.log(error);
        this.error = 'Some error occurred, could not delete technology.';
        this.success = undefined;
      },
    });
  }

  public showAddTechnology() {
    this.isAdd = true;
  }

  public hideAddTechnology() {
    this.isAdd = false;
    this.updateTech = undefined;
  }

  public onUpdate(technology: ITechnology) {
    this.showAddTechnology();
    this.updateTech = technology;
  }

  public dismissAlert() {
    this.error = undefined;
    this.success = undefined;
  }
}
