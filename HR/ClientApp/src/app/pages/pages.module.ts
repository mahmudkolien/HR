import { Shared } from './shared/shared';

import { DashboardModule } from './dashboard/dashboard.module';
import { NgModule } from '@angular/core';
import { NbMenuModule } from '@nebular/theme';

import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { MiscellaneousModule } from './miscellaneous/miscellaneous.module';
import { LayoutModule } from './layout/layout.module';
import { UserComponent } from './user/user.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { ViewUserComponent } from './user/view-user/view-user.component';
import { UserModule } from './user/user.module';
import { CommonModule } from '@angular/common';

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
