import { Component, OnInit } from '@angular/core';
import { PaginationConfig } from '../../shared/pagination-config.model';
import { IUserRoleQuery } from '../shared/user-role.model';
import { IQueryResult } from '../../shared/query-result.model';
import { UserRoleService } from '../shared/user-role.service';
import { Router } from '@angular/router';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { Shared } from '../../../shared/shared';
import { ViewUserRoleComponent } from '../view-user-role/view-user-role.component';
import { DeleteUserRoleComponent } from '../delete-user-role/delete-user-role.component';

@Component({
  selector: 'app-user-role-list',
  templateUrl: './user-role-list.component.html',
  styleUrls: ['./user-role-list.component.scss']
})
export class UserRoleListComponent implements OnInit {

  private readonly PAGE_SIZE;

  paginationConfig: PaginationConfig;
  query: IUserRoleQuery;
  queryResult: IQueryResult;
  columns: any[];

  constructor(
    private userRoleService: UserRoleService,
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
    this.populateUserRoles();
  }

  populateUserRoles() {
    this.userRoleService.getUserRoles(this.query).subscribe(data => {
        const value = (<IQueryResult>data);
        this.queryResult = value;
        this.setPaginationConfig(this.query.page, this.query.pageSize, this.queryResult.totalItems);
      });
  }

  initiateColumns() {
    this.columns = [
      { title: '#' },
      { title: 'Name', key: 'name', isSortable: true },
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
    this.populateUserRoles();
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateUserRoles();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateUserRoles();
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateUserRoles();
  }

  absoluteSerial(indexOnPage: number): number {
    return this.paginationConfig.itemsPerPage * (this.paginationConfig.currentPage - 1) + (indexOnPage + 1);
  }

  showDetails(id) {
    this.dialogService.open(ViewUserRoleComponent, {
      context: {
        id: id,
      },
    });
  }

  onDelete(id, name) {
    this.dialogService.open(DeleteUserRoleComponent, {
      context: {
        id: id,
        name: name,
      },
      closeOnBackdropClick: false,
    }).onClose.subscribe(data => {
      if (data) {
        this.toastrService.success(name + '\'s data has been successfully deleted.', 'Successfully deleted.');
        this.populateUserRoles();
      }
    });
  }

}
