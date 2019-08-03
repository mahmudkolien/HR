import { messages } from './../../../ngx-pages/extra-components/chat/messages';
import { UserRoleService } from './../shared/user-role.service';
import { IUserRole } from './../shared/user-role.model';

import { Component, OnInit, ChangeDetectorRef, ErrorHandler } from '@angular/core';
import { ISaveUser } from '../shared/user.model';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { NbToastrService } from '@nebular/theme';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  user: ISaveUser = {
    id: '',
    fullName: '',
    userName: '',
    email: '',
    userRoleId: '',
    isDeleted: false,
  };
  userRoles: IUserRole[] = [];
  submitted: boolean = false;
  errors: string[] = [];
  showMessages: any = { success: false, error: false };
  messages: string[] = [];

  constructor(
    private userService: UserService,
    private userRoleService: UserRoleService,
    private toastrService: NbToastrService) { }

  ngOnInit() {
    this.userRoleService.getUserRoles().subscribe(data => {
      this.userRoles = <IUserRole[]>data;
    });
  }

  onFormSubmit() {
    if (this.user.id) {
      this.userService.update(this.user).subscribe(
        data => {
          this.toastrService.success('User has been successfully updated.', 'Successfully updated.');
        });
    } else {
      this.userService.create(this.user).subscribe(
        data => {
          this.toastrService.success('User has been successfully added.', 'Successfully added.');
        });
    }
  }

}
