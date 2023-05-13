import { Component, Input } from '@angular/core';
import { ITest } from '../interfaces/test.interface';

@Component({
  selector: 'app-test-list-item',
  templateUrl: './test-list-item.component.html',
  styleUrls: ['./test-list-item.component.scss'],
})
export class TestListItemComponent {
  @Input() test!: ITest;
}
