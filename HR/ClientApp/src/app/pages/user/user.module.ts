
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
  NbAlertModule,
  NbDialogModule} from '@nebular/theme';
import { LayoutModule } from '../layout/layout.module';
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { UserRoleService } from '../user-role/shared/user-role.service';

@NgModule({
  declarations: [
    UserComponent,
    UserListComponent,
    UserFormComponent,
    ViewUserComponent,
    DeleteUserComponent,
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
    NgxPaginationModule,
    NbDialogModule.forChild(),
  ],
  providers: [
    UserService,
    UserRoleService,
  ],
  entryComponents: [
    ViewUserComponent,
    DeleteUserComponent,
  ],
})
export class UserModule { }
