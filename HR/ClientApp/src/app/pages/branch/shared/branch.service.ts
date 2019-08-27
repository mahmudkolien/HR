import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class BranchService 
{

  branchEndpoint:string = '/api/branches';
  constructor(private http: HttpClient) {

  }
  getBranchs() {
    return this.http.get(this.branchEndpoint);
  }
  saveBranch(branch)
  {
    return this.http.post(this.branchEndpoint,branch);
  }
  updateBranch(branch)
  {
    return this.http.put(this.branchEndpoint,branch);
  }
  deleteBranch(id)
  {
    return this.http.delete(this.branchEndpoint+"/"+id);
  }
}
