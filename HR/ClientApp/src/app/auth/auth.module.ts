import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { AuthComponent } from './auth.component';
import { LogoutComponent } from './logout/logout.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { RegisterComponent } from './register/register.component';
import { RequestPasswordComponent } from './request-password/request-password.component';

@NgModule({
  declarations: [
    LoginComponent,
    AuthComponent,
    LogoutComponent,
    ResetPasswordComponent,
    RegisterComponent,
    RequestPasswordComponent],
  imports: [
  ]
})
export class AuthModule { }
