import { AuthService } from './../shared/auth.service';
import { ILoginUser } from './../shared/auth.model';
import { Component, OnInit } from '@angular/core';
import { IAuthUser } from '../shared/auth.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorStatus } from '../../shared/status';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  user: ILoginUser;
  submitted: boolean = false;
  errors: string[] = [];
  showMessages: any = { success: false, error: false };
  messages: string[] = [];
  returnUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService) {

      // redirect to home if already logged in
      if (this.authService.currentUserValue) {
          this.router.navigate(['/']);
      }
    this.resetForm();
  }

  ngOnInit() {
    this.resetMessages();
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    const message = this.route.snapshot.queryParams['message'];
    if (message) {
      this.showMessages.success = true;
      this.messages.push(message);
    }
  }

  resetMessages() {
    this.showMessages.success = false;
    this.messages = [];
    this.showMessages.error = false;
    this.errors = [];
  }

  resetForm(form?) {
    if (form)
      form.resetForm();

    this.user = {
      userName: '',
      password: '',
      rememberMe: false,
    };
  }

  login() {
    this.resetMessages();
    this.authService.login(this.user).subscribe(
      data => {
        this.router.navigate([this.returnUrl]);
      },
      error => {
        if (error.error.status === ErrorStatus.FirstLogin) {
          this.router.navigate(['/auth/reset-password'],
          { queryParams: { userName: error.error.userName, message: error.error.message, returnUrl: this.returnUrl } });
        }

        this.showMessages.error = true;
        this.errors.push(error.error.message || error.message);
        this.user.password = '';
        console.error(error);
      },
    );
  }
}
