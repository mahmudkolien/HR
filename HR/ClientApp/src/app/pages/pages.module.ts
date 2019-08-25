import { Shared } from './shared/shared';
import { DashboardModule } from './dashboard/dashboard.module';
import { NgModule } from '@angular/core';
<<<<<<< HEAD

=======
>>>>>>> 82a9553b838afd5689eeca4d50d421f8bc7c1153
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
<<<<<<< HEAD
=======
import { DepartmentModule } from './department/shared/department.module';
>>>>>>> 82a9553b838afd5689eeca4d50d421f8bc7c1153

@NgModule({
  imports: [
    PagesRoutingModule,
    LayoutModule,
    NbMenuModule,
    DashboardModule,
    MiscellaneousModule,
    UserModule,
  ],
  declarations: [
    PagesComponent,
  ],
  providers: [
    Shared,
  ],
})
export class PagesModule {
}
