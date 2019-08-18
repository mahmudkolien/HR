import { NbDialogRef } from '@nebular/theme';
import { Component, OnInit, Input } from '@angular/core';
import { IUser } from '../shared/user.model';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-view-user',
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.scss']
})
export class ViewUserComponent implements OnInit {

  @Input() id: any;
  user: IUser = {
    id: '',
    fullName: '',
    userName: '',
    email: '',
    userRole: {id: '', name: ''},
    isDeleted: false,
    createdOn: null,
    updatedOn: null,
    createdById: '',
    updatedById: '',
  };

  constructor(
    private userService: UserService,
    protected dialogRef: NbDialogRef<ViewUserComponent>) {
  }

  ngOnInit() {
    // tslint:disable-next-line:no-console
    this.userService.getUser(this.id).subscribe(data => {
      this.user = <IUser>data;
      // tslint:disable-next-line:no-console
      console.log(this.id);
      // tslint:disable-next-line:no-console
      console.log(this.user);
    });
  }

  dismiss() {
    this.dialogRef.close();
  }

}
