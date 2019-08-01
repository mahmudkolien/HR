import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, catchError, retry } from 'rxjs/operators';
import { IUser, ISaveUser } from './user.model';
import { Shared } from '../../shared/shared';
import { throwError } from 'rxjs';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private readonly usersEndpoint = '/api/users';
  private readonly httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

  constructor(private http: HttpClient, private shared: Shared) { }

  create(user: ISaveUser) {
    user.id = Guid.EMPTY;
    return this.http.post(this.usersEndpoint, user)
      .pipe(retry(1), catchError(this.handleError));
  }

  getUser(id) {
    return this.http.get(this.usersEndpoint + '/' + id)
      .pipe(retry(1), catchError(this.handleError));
  }

  getUsers(filter?) {
    // let term: string;
    // term = term.trim();
    // const options = term ? { params: new HttpParams().set('name', term) } : {};

    return this.http.get(this.usersEndpoint + '?' + this.shared.toQueryString(filter))
      .pipe(retry(1), catchError(this.handleError));
  }


  update(user: ISaveUser) {
    return this.http.put(this.usersEndpoint + '/' + user.id, user)
      .pipe(retry(1), catchError(this.handleError));
  }

  delete(id) {
    return this.http.delete(this.usersEndpoint + '/' + id)
      .pipe(retry(1), catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  }

}
