import { RolePermission } from './../shared/user-role-permission';
import { UserListComponent } from './user/user-list/user-list.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { NotFoundComponent } from './miscellaneous/not-found/not-found.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { AuthGuard } from '../app.auth-guard';
import { UserRoleFormComponent } from './user-role/user-role-form/user-role-form.component';
import { UserRoleListComponent } from './user-role/user-role-list/user-role-list.component';

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
      canActivate: [AuthGuard],
      data: { roles: [RolePermission.SuperAdmin, RolePermission.UserView] },
    },
    {
      path: 'user/new',
      component: UserFormComponent,
      canActivate: [AuthGuard],
      data: { roles: [RolePermission.SuperAdmin, RolePermission.UserCreate] },
    },
    {
      path: 'user/edit/:id',
      component: UserFormComponent,
      canActivate: [AuthGuard],
      data: { roles: [RolePermission.SuperAdmin, RolePermission.UserEdit] },
    },
    {
      path: 'userrole',
      component: UserRoleListComponent,
      canActivate: [AuthGuard],
      data: { roles: [RolePermission.SuperAdmin, RolePermission.UserRoleView] },
    },
    {
      path: 'userrole/new',
      component: UserRoleFormComponent,
      canActivate: [AuthGuard],
      data: { roles: [RolePermission.SuperAdmin, RolePermission.UserRoleCreate] },
    },
    {
      path: 'userrole/edit/:id',
      component: UserRoleFormComponent,
      canActivate: [AuthGuard],
      data: { roles: [RolePermission.SuperAdmin, RolePermission.UserRoleEdit] },
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
