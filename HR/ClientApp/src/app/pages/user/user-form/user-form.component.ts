import { messages } from './../../../ngx-pages/extra-components/chat/messages';
import { UserRoleService } from './../shared/user-role.service';
import { IUserRole } from './../shared/user-role.model';

import { Component, OnInit, ChangeDetectorRef, ErrorHandler } from '@angular/core';
import { ISaveUser, IUser } from '../shared/user.model';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { UserService } from '../shared/user.service';
import { NbToastrService } from '@nebular/theme';
import { throwError } from 'rxjs';
import { IQueryResult } from '../../shared/query-result.model';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  user: ISaveUser;
  userRoles: IUserRole[] = [];
  submitted: boolean = false;
  errors: string[] = [];
  showMessages: any = { success: false, error: false };
  messages: string[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private userRoleService: UserRoleService,
    private toastrService: NbToastrService) {
      this.resetForm();
    }

  ngOnInit() {
    this.userRoleService.getUserRoles().subscribe(data => {
      this.userRoles = (<IQueryResult>data).items;
    });
    this.populateUser();
  }

  onFormSubmit(form) {
    if (this.user.id) {
      this.userService.update(this.user).subscribe(
        data => {
          this.toastrService.success('User has been successfully updated.', 'Successfully updated.');
          this.resetForm(form);
          this.populateUser();
        });
    } else {
      this.userService.create(this.user).subscribe(
        data => {
          this.toastrService.success('User has been successfully added.', 'Successfully added.');
          this.resetForm(form);
        });
    }
  }

  resetForm(form?) {
    if (form)
      form.resetForm();

    this.user = {
      id: '',
      fullName: '',
      userName: '',
      email: '',
      userRoleId: '',
      isDeleted: false,
    };
  }

  populateUser() {
    // get observable with user
    // const user$ = this.route.paramMap.pipe(
    //   switchMap((params: ParamMap) =>
    //     this.userService.getUser(params.get('id'))),
    // );

    // get id
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.userService.getUser(id).subscribe(data => {
        this.setUser(<IUser>data);
      });
    }
  }

  setUser(user: IUser) {
    this.user = {
      id: user.id,
      fullName: user.fullName,
      userName: user.userName,
      email: user.email,
      userRoleId: user.userRole.id,
      isDeleted: false,
    };
  }

}
