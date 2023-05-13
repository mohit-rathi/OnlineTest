import { Component, EventEmitter, Output } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-technology',
  templateUrl: './add-technology.component.html',
  styleUrls: ['./add-technology.component.scss'],
})
export class AddTechnologyComponent {
  @Output() technologyCreate = new EventEmitter<{ techName: string }>();
  @Output() hideAddTechnologyEvent = new EventEmitter();

  public addTechnology(data: NgForm): void {
    this.technologyCreate.emit(data.value);
  }

  public hideAddTechnology() {
    this.hideAddTechnologyEvent.emit();
  }
}
