// modules
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

// components
import { DashboardComponent } from './dashboard/dashboard.component';
import { TechnologyListItemComponent } from './technology-list-item/technology-list-item.component';
import { TestListItemComponent } from './test-list-item/test-list-item.component';
import { AddTechnologyComponent } from './add-technology/add-technology.component';
import { NavbarComponent } from './navbar/navbar.component';
import { TechnologyComponent } from './technology/technology.component';
import { TestComponent } from './test/test.component';
import { AddTestComponent } from './add-test/add-test.component';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [
    DashboardComponent,
    TechnologyListItemComponent,
    TestListItemComponent,
    AddTechnologyComponent,
    NavbarComponent,
    TechnologyComponent,
    TestComponent,
    AddTestComponent,
    ProfileComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  exports: [],
})
export class AdminModule {}
