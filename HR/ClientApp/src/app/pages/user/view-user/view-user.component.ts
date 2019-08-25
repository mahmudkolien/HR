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
    mobile: '',
    gender: '',
    address: '',
    userRole: {id: '', name: ''},
    isDeleted: false,
    imageFile: '',
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
    this.userService.getUser(this.id).subscribe(data => {
      this.user = <IUser>data;
    });
  }

  dismiss() {
    this.dialogRef.close();
  }

}
