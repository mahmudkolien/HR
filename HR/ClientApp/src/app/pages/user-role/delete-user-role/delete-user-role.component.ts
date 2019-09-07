import { Component, OnInit, Input } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { UserRoleService } from '../shared/user-role.service';

@Component({
  selector: 'app-delete-user-role',
  templateUrl: './delete-user-role.component.html',
  styleUrls: ['./delete-user-role.component.scss']
})
export class DeleteUserRoleComponent implements OnInit {

  @Input() id: any;
  @Input() name: any;

  constructor(
    private userRoleService: UserRoleService,
    protected dialogRef: NbDialogRef<DeleteUserRoleComponent>) {
  }

  ngOnInit() {
  }

  cancel() {
    this.dialogRef.close();
  }

  confirm() {
    this.userRoleService.delete(this.id).subscribe(data => this.dialogRef.close(data));
  }

}
