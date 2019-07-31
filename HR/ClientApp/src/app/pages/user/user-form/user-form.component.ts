import { UserRoleService } from './../shared/user-role.service';
import { IUserRole } from './../shared/user-role.model';

import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ISaveUser } from '../shared/user.model';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

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

  constructor(private userService: UserService, private userRoleService: UserRoleService) { }

  ngOnInit() {
    this.userRoleService.getUserRoles().subscribe(data => {
      this.userRoles = <IUserRole[]>data;
      // tslint:disable-next-line:no-console
      console.log(this.userRoles);
    });
  }

  onFormSubmit() {
    if (this.user.id) {
      this.userService.update(this.user).subscribe(
        data => {
          // tslint:disable-next-line:no-console
          console.log('update', this.user);
        },
        error => {
          // tslint:disable-next-line:no-console
          console.log('update-err', this.user);
        });
    } else {
      // tslint:disable-next-line:no-console
      this.userService.create(this.user).subscribe(
        data => {
          // tslint:disable-next-line:no-console
          console.log('create', this.user);
        },
        error => {
          // tslint:disable-next-line:no-console
          console.log('create-err', this.user);
        });
    }
  }

}
