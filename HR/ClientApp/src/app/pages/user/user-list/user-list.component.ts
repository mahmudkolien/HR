import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { IUser } from '../shared/user.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  users: IUser[] = [];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUsers().subscribe(data => this.users = <IUser[]>data);
  }

}
