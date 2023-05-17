import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-technology',
  templateUrl: './add-technology.component.html',
  styleUrls: ['./add-technology.component.scss'],
})
export class AddTechnologyComponent {
  public technologyForm = new FormGroup({
    techName: new FormControl(''),
  });
  public updateId: number | undefined;
  @Input() set updateTech(
    technology: { id: number; techName: string } | undefined
  ) {
    if (technology) {
      this.updateId = technology.id;
      this.technologyForm.setValue({
        techName: technology.techName,
      });
    } else {
      this.updateId = undefined;
      this.technologyForm.reset();
    }
  }
  @Output() technologyCreate = new EventEmitter<{ techName: string }>();
  @Output() technologyUpdate = new EventEmitter<{
    id: number;
    techName: string;
  }>();
  @Output() hideAddTechnology = new EventEmitter();

  public onAddTechnology(data: any): void {
    this.technologyCreate.emit(data.value);
  }

  public onUpdateTechnology(data: any): void {
    this.technologyUpdate.emit({
      id: <number>this.updateId,
      techName: data.techName,
    });
  }

  public onHideAddTechnology() {
    this.updateId = undefined;
    this.hideAddTechnology.emit();
  }
}
