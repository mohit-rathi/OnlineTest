// modules
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

// components
import { DashboardComponent } from './dashboard/dashboard.component';
import { TechnologyListItemComponent } from './technology-list-item/technology-list-item.component';
import { TestListItemComponent } from './test-list-item/test-list-item.component';
import { AddTechnologyComponent } from './add-technology/add-technology.component';
import { NavbarComponent } from './navbar/navbar.component';
import { TechnologyComponent } from './technology/technology.component';
import { TestComponent } from './test/test.component';
import { AddTestComponent } from './add-test/add-test.component';

// interceptors
import { TokenInterceptor } from '../interceptors/token.interceptor';

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
  ],
  imports: [CommonModule, AdminRoutingModule, FormsModule, HttpClientModule],
  exports: [],
})
export class AdminModule {}
