import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IAuthUser, ILoginUser } from './auth.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly authEndpoint = '/api/auth';
  private currentUserSubject: BehaviorSubject<IAuthUser>;
  public currentUser: Observable<IAuthUser>;

  constructor(private http: HttpClient) {
      this.currentUserSubject = new BehaviorSubject<IAuthUser>(JSON.parse(localStorage.getItem('currentUser')));
      this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): IAuthUser {
      return this.currentUserSubject.value;
  }

  login(login: ILoginUser) {
      return this.http.post(this.authEndpoint, login)
          .pipe(map((authUser: IAuthUser) => {
              // login successful if there's a jwt token in the response
              if (authUser && authUser.token) {
                  // store user details and jwt token in local storage to keep user logged in between page refreshes
                  localStorage.setItem('currentUser', JSON.stringify(authUser));
                  this.currentUserSubject.next(authUser);
              }

              return authUser;
          }));
  }

  logout() {
      // remove user from local storage to log user out
      localStorage.removeItem('currentUser');
      this.currentUserSubject.next(null);
  }
}
