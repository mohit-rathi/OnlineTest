import { Component, EventEmitter, Output } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-test',
  templateUrl: './add-test.component.html',
  styleUrls: ['./add-test.component.scss'],
})
export class AddTestComponent {
  @Output() testCreate = new EventEmitter<{ testName: string }>();
  @Output() hideAddTestEvent = new EventEmitter();

  public addTest(data: NgForm): void {
    this.testCreate.emit(data.value);
  }

  public hideAddTest() {
    this.hideAddTestEvent.emit();
  }
}
