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
    return this.http.post(this.usersEndpoint, this.shared.toFormData(user));
  }

  getUser(id) {
    return this.http.get(this.usersEndpoint + '/' + id);
  }

  getUsers(filter?) {
    // let term: string;
    // term = term.trim();
    // const options = term ? { params: new HttpParams().set('name', term) } : {};

    return this.http.get(this.usersEndpoint + '?' + this.shared.toQueryString(filter));
  }


  update(user: ISaveUser) {
    return this.http.put(this.usersEndpoint + '/' + user.id, this.shared.toFormData(user));
  }

  delete(id) {
    return this.http.delete(this.usersEndpoint + '/' + id);
  }

}
