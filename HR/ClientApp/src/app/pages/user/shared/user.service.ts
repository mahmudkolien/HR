import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IUser, ISaveUser } from './user.model';
import { Observable } from 'rxjs';
import { Shared } from '../../shared/shared';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private readonly usersEndpoint = '/api/users';

  constructor(private http: Http, private shared: Shared) { }

  create(user: ISaveUser) {
    return this.http.post(this.usersEndpoint, user)
      .pipe(map(res => res.json()));
  }

  getUser(id) {
    return this.http.get(this.usersEndpoint + '/' + id)
      .pipe(map(res => res.json()));
  }

  getUsers(filter?) {
    return this.http.get(this.usersEndpoint + '?' + this.shared.toQueryString(filter))
      .pipe(map(res => res.json()));
  }


  update(user: ISaveUser) {
    return this.http.put(this.usersEndpoint + '/' + user.Id, user)
      .pipe(map(res => res.json()));
  }

  delete(id) {
    return this.http.delete(this.usersEndpoint + '/' + id)
      .pipe(map(res => res.json()));
  }

}
