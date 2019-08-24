import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { IDepartment, ISaveDepartment } from './department.model';
@Injectable({
  providedIn: 'root',
})
export class DepartmentService {

  departmentEndpoint:string = '/api/departments';
  constructor(private http: Http) {

  }
  getDepartments() {
    return this.http.get(this.departmentEndpoint).map(res => res.json());
  }
  saveDepartment(department)
  {
    return this.http.post(this.departmentEndpoint,department).map(res => res.json());
  }
  updateDepartment(department)
  {
    return this.http.put(this.departmentEndpoint,department).map(res => res.json());
  }
  deleteDepartment(id)
  {
    return this.http.delete(this.departmentEndpoint+"/"+id).map(res => res.json());
  }
}
