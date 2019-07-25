import { Component, OnInit } from '@angular/core';
import { MENU_ITEMS } from './pages-menu';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  // tslint:disable-next-line:trailing-comma
  styleUrls: ['./pages.component.scss']
})
export class PagesComponent {

  menu = MENU_ITEMS;

}
