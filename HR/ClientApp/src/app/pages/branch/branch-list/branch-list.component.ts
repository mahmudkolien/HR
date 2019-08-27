import { Component, OnInit } from '@angular/core';
import { BranchService } from '../shared/branch.service';
import { IQueryResult } from '../../shared/query-result.model';
import { NbDialogService } from '@nebular/theme';
import { BranchAddEditComponent } from '../branch-add-edit/branch-add-edit.component';
import { IBranch, ISaveBranch } from '../shared/branch.model';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.scss']
})
export class BranchListComponent implements OnInit {
queryResult : IQueryResult;
saveBranch : ISaveBranch={
  id : '',
  branchName:'',
  phoneNo:'',
  companyId:'',
  address:'',
  email:''
}
  constructor(private dialogService: NbDialogService,private branService: BranchService) { 
    this.initiateQueryResult();
  }

  ngOnInit() 
  {
    this.initiateQueryResult();
  }
  initiateQueryResult() {
    this.queryResult = {
      totalItems: 0,
      items: [],
    };
    this.branService.getBranchs().subscribe(data => this.queryResult = <IQueryResult>data);
  }

  open()
  {
    this.dialogService.open(BranchAddEditComponent, {
      context: { },
    }).onClose.subscribe(data => {
      this.initiateQueryResult();
    });
  }
  edit(branch:IBranch)
  {
    this.dialogService.open(BranchAddEditComponent, {
      context: {branch: this.saveBranch},
    }).onClose.subscribe(data => {
      this.initiateQueryResult();
    });
  }
}
