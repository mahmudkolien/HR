import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IAuthUser, ILoginUser, IResetPassword } from './auth.model';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private readonly authEndpoint = '/api/auth';
  private currentUserSubject: BehaviorSubject<IAuthUser>;
  public currentUser: Observable<IAuthUser>;

  constructor(
      private http: HttpClient,
      private router: Router) {
      this.currentUserSubject = new BehaviorSubject<IAuthUser>(JSON.parse(localStorage.getItem('currentUser')));
      this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): IAuthUser {
      return this.currentUserSubject.value;
  }

  login(login: ILoginUser) {
    return this.http.post(this.authEndpoint + '/login', login)
        .pipe(map((authUser: IAuthUser) => {
            if (authUser && authUser.token) {
                localStorage.setItem('currentUser', JSON.stringify(authUser));
                this.currentUserSubject.next(authUser);
            }

            return authUser;
        }));
  }

  logout() {
    return this.http.post(this.authEndpoint + '/logout', null)
        .pipe(map((data) => {
            if (data) {
                localStorage.removeItem('currentUser');
                this.currentUserSubject.next(null);
            }
            return data;
        }));
  }

  resetPassword(reset: IResetPassword) {
    return this.http.post(this.authEndpoint + '/resetPassword', reset)
        .pipe(map((data) => {
            if (data) {
            localStorage.removeItem('currentUser');
            this.currentUserSubject.next(null);
            }
            return data;
        }));
  }
}
