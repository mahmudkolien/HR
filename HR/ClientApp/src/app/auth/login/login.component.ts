import { ILoginUser } from './../shared/auth.model';
import { Component, OnInit } from '@angular/core';
import { IAuthUser } from '../shared/auth.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user: ILoginUser;
  submitted: boolean = false;
  errors: string[] = [];
  showMessages: any = { success: false, error: false };
  messages: string[] = [];

  constructor() { }

  ngOnInit() {
    // tslint:disable-next-line: no-console
    console.log('call login');
  }

  login() {
    // tslint:disable-next-line: no-console
    console.log(this.user);
  }
}
