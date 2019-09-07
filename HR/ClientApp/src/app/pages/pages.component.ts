import { Component, OnInit } from '@angular/core';
import { MENU_ITEMS } from './pages-menu';
import { IAuthUser } from '../auth/shared/auth.model';
import { Router } from '@angular/router';
import { AuthService } from '../auth/shared/auth.service';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  // tslint:disable-next-line:trailing-comma
  styleUrls: ['./pages.component.scss']
})
export class PagesComponent {

  menu = MENU_ITEMS;

  constructor() {
  }

}
