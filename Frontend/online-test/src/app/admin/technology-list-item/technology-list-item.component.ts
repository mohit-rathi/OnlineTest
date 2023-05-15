import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment.development';

// interfaces
import { ITechnology } from '../interfaces/technology.interface';

@Component({
  selector: 'app-technology-list-item',
  templateUrl: './technology-list-item.component.html',
  styleUrls: ['./technology-list-item.component.scss'],
})
export class TechnologyListItemComponent {
  @Input() technology!: ITechnology;
  private apiBaseUrl: string = environment.apiBaseUrl;

  constructor(private router: Router) {}

  public displayTests(id: number) {
    this.router.navigateByUrl('dashboard/technologies/' + id + '/tests');
  }
}