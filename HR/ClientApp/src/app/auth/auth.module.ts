
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { AuthComponent } from './auth.component';
import { LogoutComponent } from './logout/logout.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { RegisterComponent } from './register/register.component';
import { RequestPasswordComponent } from './request-password/request-password.component';
import { AuthRoutingModule } from './auth-routing.module';
import {
  NbInputModule,
  NbCardModule,
  NbButtonModule,
  NbActionsModule,
  NbCheckboxModule,
  NbRadioModule,
  NbDatepickerModule,
  NbSelectModule,
  NbIconModule,
  NbAlertModule,
  NbDialogModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LayoutModule } from '../pages/layout/layout.module';

@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    LogoutComponent,
    ResetPasswordComponent,
    RegisterComponent,
    RequestPasswordComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    LayoutModule,
    NbInputModule,
    NbCardModule,
    NbButtonModule,
    NbActionsModule,
    NbCheckboxModule,
    NbRadioModule,
    NbDatepickerModule,
    NbSelectModule,
    NbIconModule,
    FormsModule,
    NbAlertModule,
    RouterModule,
    NbDialogModule.forChild(),
  ],
})
export class AuthModule { }
