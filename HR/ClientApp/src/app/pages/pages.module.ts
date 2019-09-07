import { UserRoleModule } from './user-role/user-role.module';
import { AuthModule } from './../auth/auth.module';
import { Shared } from '../shared/shared';
import { DashboardModule } from './dashboard/dashboard.module';
import { NgModule } from '@angular/core';

import {
  NbMenuModule,
  NbInputModule,
  NbCardModule,
  NbButtonModule,
  NbActionsModule,
  NbCheckboxModule,
  NbRadioModule,
  NbDatepickerModule,
  NbSelectModule,
  NbIconModule,
  NbAlertModule} from '@nebular/theme';

import { LayoutModule } from './layout/layout.module';
import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { MiscellaneousModule } from './miscellaneous/miscellaneous.module';
import { UserModule } from './user/user.module';
import { CommonModule } from '@angular/common';

import { UserComponent } from './user/user.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { ViewUserComponent } from './user/view-user/view-user.component';
import { UserRoleComponent } from './user-role/user-role.component';

@NgModule({
  imports: [
    PagesRoutingModule,
    LayoutModule,
    // AuthModule,
    NbMenuModule,
    DashboardModule,
    MiscellaneousModule,
    UserModule,
    UserRoleModule,
  ],
  declarations: [
    PagesComponent,
  ],
  providers: [
  ],
})
export class PagesModule {
}
