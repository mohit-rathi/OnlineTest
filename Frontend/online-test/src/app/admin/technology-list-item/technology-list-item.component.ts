import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

// interfaces
import { ITechnology } from '../interfaces/technology.interface';

@Component({
  selector: 'app-technology-list-item',
  templateUrl: './technology-list-item.component.html',
  styleUrls: ['./technology-list-item.component.scss'],
})
export class TechnologyListItemComponent {
  @Input() technology!: ITechnology;
  @Output() update = new EventEmitter<{ id: number; techName: string }>();
  @Output() delete = new EventEmitter<number>();

  constructor(private router: Router, private activatedRoute: ActivatedRoute) {}

  public displayTests(id: number) {
    this.router.navigate([id, 'tests'], { relativeTo: this.activatedRoute });
  }

  public onUpdate(technology: { id: number; techName: string }) {
    this.update.emit(technology);
  }

  public onDelete(id: number) {
    this.delete.emit(id);
  }
}
