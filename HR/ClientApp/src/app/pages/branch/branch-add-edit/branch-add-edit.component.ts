import { Component, OnInit, Input } from '@angular/core';
import { ISaveBranch } from '../shared/branch.model';
import { CompanyService } from '../../company/shared/company.service';
import { ICompany } from '../../company/shared/company.model';
import { IQueryResult } from '../../shared/query-result.model';
import { BranchService } from '../shared/branch.service';
import { NbDialogRef, NbToastrService } from '@nebular/theme';

@Component({
  selector: 'app-branch-add-edit',
  templateUrl: './branch-add-edit.component.html',
  styleUrls: ['./branch-add-edit.component.scss']
})
export class BranchAddEditComponent implements OnInit {
  companies :IQueryResult;
@Input() branch: ISaveBranch={
  id : '',
  branchName:'',
  phoneNo:'',
  companyId:'',
  address:'',
  email:''
};
  constructor(protected ref: NbDialogRef<BranchAddEditComponent>,private companyService : CompanyService,private branchService: BranchService,private toastrService: NbToastrService) 
  {
    this.initiateQueryResult()
  }

  ngOnInit() 
  {
    this.initiateQueryResult();
  }

  onSubmit()
  {
    if(this.branch.id)
    {
      this.branchService.updateBranch(this.branch).subscribe(x => 
        {
          console.log(x);
          this.ref.close();
          this.toastrService.success('Update Successful','Message');
        });
     
    }
    else
    {
      this.branch.id ="00000000-0000-0000-0000-000000000000";
      this.branchService.saveBranch(this.branch).subscribe(x => 
      {
        
        this.ref.close();
        this.toastrService.success('Create Successful','Message');
      });
    }
  }

  initiateQueryResult() {
    this.companies = {
      totalItems: 0,
      items: [],
    };
    this.companyService.getCompanies().subscribe(data => this.companies = <IQueryResult>data)
  }

}
