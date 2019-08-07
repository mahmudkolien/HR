import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { IUser } from '../shared/user.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  currentPage: number = 1;
  itemsPerPage: number = 2;
  totalItems: number = 20;
  users: IUser[] = [];

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userService.getUsers().subscribe(data => {
        this.users = <IUser[]>data;
        this.totalItems = this.users.length;
      });
  }

  absoluteIndex(indexOnPage: number): number {
    return this.itemsPerPage * (this.currentPage - 1) + (indexOnPage + 1);
  }

}
