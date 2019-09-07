import { AuthService } from './../shared/auth.service';
import { ILoginUser } from './../shared/auth.model';
import { Component, OnInit } from '@angular/core';
import { IAuthUser } from '../shared/auth.model';
import { ActivatedRoute, Router } from '@angular/router';

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

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
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
    this.showMessages.error = false;
    this.errors = [];
    this.authService.login(this.user).subscribe(
      data => {
        this.router.navigate([this.returnUrl]);
      },
      error => {
        this.showMessages.error = true;
        this.errors.push(error.error.message || error.message);
        this.user.password = '';
        // tslint:disable-next-line:no-console
        console.log(error);
      },
    );
  }
}
