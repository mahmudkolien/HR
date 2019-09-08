import { Component, OnInit } from '@angular/core';
import { IResetPassword } from '../shared/auth.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss'],
})
export class ResetPasswordComponent implements OnInit {

  user: IResetPassword;
  submitted: boolean = false;
  errors: string[] = [];
  showMessages: any = { success: false, error: false };
  messages: string[] = [];
  returnUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService) {
    this.resetForm();
  }

  ngOnInit() {
    this.resetMessages();
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    const message = this.route.snapshot.queryParams['message'];
    if (message) {
      this.showMessages.error = true;
      this.errors.push(message);
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
      userName:  this.authService.currentUserValue ?
                    this.authService.currentUserValue.userName : this.route.snapshot.queryParams['userName'],
      password: '',
      newPassword: '',
      confirmPassword: '',
    };
  }

  confirm() {
    this.resetMessages();
    this.authService.resetPassword(this.user).subscribe(
      data => {
        this.router.navigate(['/auth/login'],
        { queryParams: {
          message: 'Your password has been successfully changed. Please login again.',
          returnUrl: this.returnUrl } });
      },
      error => {
        this.showMessages.error = true;
        this.errors.push(error.error.message || error.message);
        this.resetForm();
        console.error(error);
      },
    );
  }
}
