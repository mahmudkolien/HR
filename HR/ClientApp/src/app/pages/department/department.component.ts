import { Component, OnInit,TemplateRef } from '@angular/core';
import { DepartmentService } from './shared/department.service';
import { NbDialogService, NbToastrService } from '@nebular/theme';

import { IDepartment, ISaveDepartment } from './shared/department.model';
import { NbDialogRef } from '@nebular/theme';
import { DeparmentAddComponent } from './deparment-add/deparment-add.component';
import { ThrowStmt } from '@angular/compiler';
import { IQueryResult } from '../shared/query-result.model';
@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss']
})
export class DepartmentComponent implements OnInit {
  queryResult: IQueryResult;
  saveDepartment : ISaveDepartment={ id:"00000000-0000-0000-0000-000000000000",isDeleted:false,departmentName:''};
  constructor(private dialogService: NbDialogService,private departmentService: DepartmentService,private toastrService: NbToastrService) 
  {
    this.initiateQueryResult();
   
  }  
  ngOnInit() 
  {
    this.mapDepartmentsData();
  }
  edit(department)
  {
    this.saveDepartment.departmentName = department.departmentName;
    this.saveDepartment.id = department.id;
    this.dialogService.open(DeparmentAddComponent, {
      context: {department: this.saveDepartment},
    }).onClose.subscribe(data => {
      this.mapDepartmentsData();
    });
  }
  open()
   {
      this.dialogService.open(DeparmentAddComponent, {
        context: { },
      }).onClose.subscribe(data => {
        this.mapDepartmentsData();
      });
  }
  delete(id)
  {
    if(confirm("Are you want to delete?"))
    {
      this.departmentService.deleteDepartment(id).subscribe(data=>{
        this.toastrService.success('Delete Successful');
       this.mapDepartmentsData();
      });
    }
  }

  initiateQueryResult() {
    this.queryResult = {
      totalItems: 0,
      items: [],
    };
  }
  mapDepartmentsData(){
    this.departmentService.getDepartments().subscribe(data => this.queryResult = <IQueryResult>data);
  }
  
 

}
