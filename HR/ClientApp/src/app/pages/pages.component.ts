import { Component, OnInit } from '@angular/core';
import { MENU_ITEMS } from './pages-menu';
import { IAuthUser } from '../auth/shared/auth.model';
import { Router } from '@angular/router';
import { AuthService } from '../auth/shared/auth.service';
import { Role } from '../shared/Role';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  // tslint:disable-next-line:trailing-comma
  styleUrls: ['./pages.component.scss']
})
export class PagesComponent {

  menu = MENU_ITEMS;
  currentUser: IAuthUser;

  constructor(
      private router: Router,
      private authService: AuthService) {
      this.authService.currentUser.subscribe(x => this.currentUser = x);
  }

  get isAdmin() {
      return this.currentUser && this.currentUser.role === Role.Admin;
  }

  get isSuperAdmin() {
      return this.currentUser && this.currentUser.role === Role.SuperAdmin;
  }

  logout() {
      this.authService.logout();
      this.router.navigate(['/login']);
  }
}
