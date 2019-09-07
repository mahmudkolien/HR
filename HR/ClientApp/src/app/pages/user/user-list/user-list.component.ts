import { ViewUserComponent } from './../view-user/view-user.component';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { PaginationConfig } from './../../shared/pagination-config.model';
import { IUserQuery } from './../shared/user.model';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { IUser } from '../shared/user.model';
import { IQueryResult } from '../../shared/query-result.model';
import { Shared } from '../../../shared/shared';
import { DeleteUserComponent } from '../delete-user/delete-user.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  private readonly PAGE_SIZE;

  paginationConfig: PaginationConfig;
  query: IUserQuery;
  queryResult: IQueryResult;
  columns: any[];

  constructor(
    private userService: UserService,
    private router: Router,
    private dialogService: NbDialogService,
    private shared: Shared,
    private toastrService: NbToastrService) {

    this.PAGE_SIZE = this.shared.PAGE_SIZE;
    this.initiateColumns();
    this.initiateQuery();
    this.initiateQueryResult();
    this.setPaginationConfig(this.query.page, this.query.pageSize, this.queryResult.totalItems);
   }

  ngOnInit() {
    this.populateUsers();
  }

  populateUsers() {
    this.userService.getUsers(this.query).subscribe(data => {
        const value = (<IQueryResult>data);
        this.queryResult = value;
        this.setPaginationConfig(this.query.page, this.query.pageSize, this.queryResult.totalItems);
      });
  }

  initiateColumns() {
    this.columns = [
      { title: '#' },
      { title: 'Name', key: 'name', isSortable: true },
      { title: 'User Name', key: 'userName', isSortable: true },
      { title: 'Email', key: 'email', isSortable: true },
      { title: 'Mobile' },
      { title: 'Address' },
      { title: 'User Role' },
      { title: '###' },
    ];
  }

  initiateQuery() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE,
      sortBy: '',
      isSortAscending: false,
      name: '',
    };
  }

  initiateQueryResult() {
    this.queryResult = {
      totalItems: 0,
      items: [],
    };
  }

  setPaginationConfig(page: number, pageSize: number, totalItems: number) {
    this.paginationConfig = {
      currentPage: page,
      itemsPerPage: pageSize,
      totalItems: totalItems,
    };
  }

  resetFilter() {
    this.initiateQuery();
    this.setPaginationConfig(this.query.page, this.query.pageSize, this.queryResult.totalItems);
    this.populateUsers();
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateUsers();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateUsers();
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateUsers();
  }

  absoluteSerial(indexOnPage: number): number {
    return this.paginationConfig.itemsPerPage * (this.paginationConfig.currentPage - 1) + (indexOnPage + 1);
  }

  showDetails(id) {
    this.dialogService.open(ViewUserComponent, {
      context: {
        id: id,
      },
    });
  }

  onDelete(id, name) {
    this.dialogService.open(DeleteUserComponent, {
      context: {
        id: id,
        name: name,
      },
      closeOnBackdropClick: false,
    }).onClose.subscribe(data => {
      if (data) {
        this.toastrService.success(name + '\'s data has been successfully deleted.', 'Successfully deleted.');
        this.populateUsers();
      }
    });
  }

}
