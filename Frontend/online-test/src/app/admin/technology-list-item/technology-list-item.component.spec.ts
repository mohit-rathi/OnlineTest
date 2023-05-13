import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechnologyListItemComponent } from './technology-list-item.component';

describe('TechnologyListItemComponent', () => {
  let component: TechnologyListItemComponent;
  let fixture: ComponentFixture<TechnologyListItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TechnologyListItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TechnologyListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
