import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, retry, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserRoleService {

  private readonly userRolesEndpoint = '/api/userroles';

  constructor(private http: HttpClient) { }

  getUserRole(id) {
    return this.http.get(this.userRolesEndpoint + '/' + id);
  }

  getUserRoles() {
    return this.http.get(this.userRolesEndpoint);
  }
}
