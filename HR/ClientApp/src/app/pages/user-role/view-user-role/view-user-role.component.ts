import { Component, OnInit, Input } from '@angular/core';
import { IUserRole } from '../shared/user-role.model';
import { UserRoleService } from '../shared/user-role.service';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'app-view-user-role',
  templateUrl: './view-user-role.component.html',
  styleUrls: ['./view-user-role.component.scss']
})
export class ViewUserRoleComponent implements OnInit {

  @Input() id: any;
  userRole: IUserRole = {
    id: '',
    roleName: '',
    isDeleted: false,
    userRolePermissions: [],
    createdOn: null,
    updatedOn: null,
    createdById: '',
    updatedById: '',
  };

  constructor(
    private userRoleService: UserRoleService,
    protected dialogRef: NbDialogRef<ViewUserRoleComponent>) {
  }

  ngOnInit() {
    this.userRoleService.getUserRole(this.id).subscribe(data => {
      this.userRole = <IUserRole>data;
    });
  }

  dismiss() {
    this.dialogRef.close();
  }

}
