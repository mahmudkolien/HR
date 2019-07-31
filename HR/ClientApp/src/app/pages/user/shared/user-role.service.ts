import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class UserRoleService {

  private readonly userRolesEndpoint = '/api/userroles';

  constructor(private http: HttpClient) { }

  getUserRole(id) {
    return this.http.get(this.userRolesEndpoint + '/' + id)
      .pipe(map(res => res));
  }

  getUserRoles() {
    return this.http.get(this.userRolesEndpoint)
      .pipe(map(res => res));
  }
}
