
import { Component, OnInit } from '@angular/core';
import { ISaveUserRole, IUserRole } from '../shared/user-role.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Shared } from '../../shared/shared';
import { UserRoleService } from '../shared/user-role.service';
import { NbToastrService } from '@nebular/theme';
import { ISaveUserRolePermission } from '../shared/user-role-permission.model';
import { UserRolePermissionData } from '../shared/user-role-permission-data';
import * as _ from 'underscore';

@Component({
  selector: 'app-user-role-form',
  templateUrl: './user-role-form.component.html',
  styleUrls: ['./user-role-form.component.scss']
})
export class UserRoleFormComponent implements OnInit {

  userRole: ISaveUserRole;
  rolePermissions: ISaveUserRolePermission[];
  submitted: boolean = false;
  errors: string[] = [];
  showMessages: any = { success: false, error: false };
  messages: string[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shared: Shared,
    private userRolePermissionData: UserRolePermissionData,
    private userRoleService: UserRoleService,
    private toastrService: NbToastrService) {
      this.resetForm();
    }

  ngOnInit() {
    this.populateUserRole();
    this.populateUserRolePermission();
  }

  onFormSubmit(form) {
    if (this.userRole.id) {
      this.userRoleService.update(this.userRole).subscribe(
        data => {
          this.toastrService.success('User Role has been successfully updated.', 'Successfully updated.');
          this.resetForm(form);
          this.populateUserRole();
        });
    } else {
      this.userRoleService.create(this.userRole).subscribe(
        data => {
          this.toastrService.success('User Role has been successfully added.', 'Successfully added.');
          this.resetForm(form);
        });
    }
  }

  resetForm(form?) {
    if (form)
      form.resetForm();

    this.userRole = {
      id: '',
      roleName: '',
      isDeleted: false,
      userRolePermissions: [],
    };
  }

  populateUserRole() {
    // get id
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.userRoleService.getUserRole(id).subscribe(data => {
        this.setUserRole(<IUserRole>data);
      });
    }
  }

  populateUserRolePermission() {
    this.rolePermissions = this.userRolePermissionData.items;
  }

  setUserRole(userRole: IUserRole) {
    this.userRole = {
      id: userRole.id,
      roleName: userRole.roleName,
      isDeleted: userRole.isDeleted,
      userRolePermissions: _.pluck(userRole.userRolePermissions, 'name'),
    };
  }

  onRolePermissionToggle(permission, $event) {
    if ($event.target.checked)
      this.userRole.userRolePermissions.push(permission);
    else {
      const index = this.userRole.userRolePermissions.indexOf(permission);
      this.userRole.userRolePermissions.splice(index, 1);
    }
  }

}
