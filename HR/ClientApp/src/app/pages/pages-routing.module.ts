import { UserListComponent } from './user/user-list/user-list.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { NotFoundComponent } from './miscellaneous/not-found/not-found.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { Role } from '../shared/Role';
import { AuthGuard } from '../app.auth-guard';

const routes: Routes = [{
  path: '',
  component: PagesComponent,
  children: [
    {
      path: 'dashboard',
      component: DashboardComponent,
    },
    {
      path: 'user',
      component: UserListComponent,
    },
    {
      path: 'user/new',
      component: UserFormComponent,
      canActivate: [AuthGuard],
      data: { roles: [Role.Admin] },
    },
    {
      path: 'user/edit/:id',
      component: UserFormComponent,
      canActivate: [AuthGuard],
      data: { roles: [Role.SuperAdmin] },
    },
    {
      path: 'miscellaneous',
      loadChildren: () => import('./miscellaneous/miscellaneous.module')
        .then(m => m.MiscellaneousModule),
    },
    {
      path: '',
      redirectTo: 'dashboard',
      pathMatch: 'full',
    },
    {
      path: '**',
      component: NotFoundComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
