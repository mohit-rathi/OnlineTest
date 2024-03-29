// modules
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// components
import { DashboardComponent } from './dashboard/dashboard.component';
import { TechnologyComponent } from './technology/technology.component';
import { TestComponent } from './test/test.component';
import { ProfileComponent } from './profile/profile.component';

// auth guard
import { AdminAuthGuard } from './guards/admin-auth.guard';

export const routes: Routes = [
  {
    path: 'dashboard',
    canActivate: [AdminAuthGuard],
    component: DashboardComponent,
    children: [
      {
        path: '',
        redirectTo: 'technologies',
        pathMatch: 'full',
      },
      {
        path: 'technologies',
        component: TechnologyComponent,
      },
      {
        path: 'technologies/:testId/tests',
        component: TestComponent,
      },
      {
        path: 'profile',
        component: ProfileComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
