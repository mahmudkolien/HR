import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  companyEndpoint:string = '/api/companies';
  monthEndPoint :string ='/api/months';
  constructor(private http: Http) {

  }
  getCompanies() {
    return this.http.get(this.companyEndpoint).map(res => res.json());
  }
  saveCompany(company)
  {
    return this.http.post(this.companyEndpoint,company).map(res => res.json());
  }
  updateCompany(company)
  {
    return this.http.put(this.companyEndpoint,company).map(res => res.json());
  }
  deleteCompany(id)
  {
    return this.http.delete(this.companyEndpoint+"/"+id).map(res => res.json());
  }
  getMonth()
  {
    return this.http.get(this.monthEndPoint).map(res=>res.json());
  }
}
