import { Component, OnInit, Input } from '@angular/core';
import { UserService } from '../shared/user.service';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.scss']
})
export class DeleteUserComponent implements OnInit {

  @Input() id: any;
  @Input() name: any;

  constructor(
    private userService: UserService,
    protected dialogRef: NbDialogRef<DeleteUserComponent>) {
  }

  ngOnInit() {
  }

  cancel() {
    this.dialogRef.close();
  }

  confirm() {
    this.userService.delete(this.id).subscribe(data => this.dialogRef.close(data));
  }

}
