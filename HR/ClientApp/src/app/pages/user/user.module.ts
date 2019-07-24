import { UserService } from './shared/user.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserFormComponent } from './user-form/user-form.component';
import { ViewUserComponent } from './view-user/view-user.component';

@NgModule({
  declarations: [
    UserComponent,
    UserListComponent,
    UserFormComponent,
    ViewUserComponent,
  ],
  imports: [
    CommonModule,
  ],
  providers: [
    UserService,
  ],
})
export class UserModule { }
