import { UserRolePermissionData } from './shared/user-role-permission-data';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoleComponent } from './user-role.component';
import { UserRoleService } from './shared/user-role.service';
import { UserRoleListComponent } from './user-role-list/user-role-list.component';
import { UserRoleFormComponent } from './user-role-form/user-role-form.component';
import { DeleteUserRoleComponent } from './delete-user-role/delete-user-role.component';
import { ViewUserRoleComponent } from './view-user-role/view-user-role.component';
import { NbInputModule, NbCardModule, NbButtonModule, NbActionsModule, NbCheckboxModule, NbRadioModule, NbDatepickerModule, NbSelectModule, NbIconModule, NbAlertModule, NbDialogModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';
import { PipesModule } from '../../pipes/pipes.module';

@NgModule({
  declarations: [
    UserRoleComponent,
    UserRoleListComponent,
    UserRoleFormComponent,
    DeleteUserRoleComponent,
    ViewUserRoleComponent,
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
    PipesModule,
  ],
  providers: [
    UserRoleService,
    UserRolePermissionData,
  ],
  entryComponents: [
    ViewUserRoleComponent,
    DeleteUserRoleComponent,
  ],
})
export class UserRoleModule { }
