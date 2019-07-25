import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IUser, ISaveUser } from './user.model';
import { Shared } from '../../shared/shared';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private readonly usersEndpoint = '/api/users';

  constructor(private http: HttpClient, private shared: Shared) { }

  create(user: ISaveUser) {
    return this.http.post(this.usersEndpoint, user)
      .pipe(map(res => res));
  }

  getUser(id) {
    return this.http.get(this.usersEndpoint + '/' + id)
      .pipe(map(res => res));
  }

  getUsers(filter?) {
    return this.http.get(this.usersEndpoint + '?' + this.shared.toQueryString(filter))
      .pipe(map(res => res));
  }


  update(user: ISaveUser) {
    return this.http.put(this.usersEndpoint + '/' + user.Id, user)
      .pipe(map(res => res));
  }

  delete(id) {
    return this.http.delete(this.usersEndpoint + '/' + id)
      .pipe(map(res => res));
  }

}
