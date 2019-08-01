import { UserRoleService } from './shared/user-role.service';
import { FormsModule } from '@angular/forms';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserComponent } from './user.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserFormComponent } from './user-form/user-form.component';
import { ViewUserComponent } from './view-user/view-user.component';

import { UserService } from './shared/user.service';
import {
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
import { LayoutModule } from '../layout/layout.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    UserComponent,
    UserListComponent,
    UserFormComponent,
    ViewUserComponent,
  ],
  imports: [
    CommonModule,
    NbInputModule,
    NbCardModule,
    NbButtonModule,
    NbActionsModule,
    NbCheckboxModule,
    NbRadioModule,
    NbDatepickerModule,
    NbSelectModule,
    NbIconModule,
    FormsModule,
    NbAlertModule,
    RouterModule,
  ],
  providers: [
    UserService,
    UserRoleService,
  ],
})
export class UserModule { }
