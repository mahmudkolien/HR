import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ISaveUserRole } from './user-role.model';
import { Guid } from 'guid-typescript';
import { Shared } from '../../shared/shared';

@Injectable({
  providedIn: 'root'
})
export class UserRoleService {

  private readonly userRolesEndpoint = '/api/userroles';

  constructor(private http: HttpClient, private shared: Shared) { }

  create(userRole: ISaveUserRole) {
    userRole.id = Guid.EMPTY;
    return this.http.post(this.userRolesEndpoint, userRole);
  }

  getUserRole(id) {
    return this.http.get(this.userRolesEndpoint + '/' + id);
  }

  getUserRoles(filter?) {
    return this.http.get(this.userRolesEndpoint + '?' + this.shared.toQueryString(filter));
  }

  update(userRole: ISaveUserRole) {
    return this.http.put(this.userRolesEndpoint + '/' + userRole.id, userRole);
  }

  delete(id) {
    return this.http.delete(this.userRolesEndpoint + '/' + id);
  }

}
