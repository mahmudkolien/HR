import { Component, OnInit, Input} from '@angular/core';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { ISaveDepartment } from '../shared/department.model';
import { DepartmentService } from '../shared/department.service';

@Component({
  selector: 'app-deparment-add',
  templateUrl: './deparment-add.component.html',
  styleUrls: ['./deparment-add.component.scss']
})
export class DeparmentAddComponent implements OnInit {

  @Input() department : ISaveDepartment={ id:'',isDeleted:false,departmentName:''};
  constructor(protected ref: NbDialogRef<DeparmentAddComponent>,private departmentService: DepartmentService,private toastrService: NbToastrService ) {}

  dismiss()
  {
    this.ref.close();
  }
  onSubmit()
  {
   
    if(this.department.id)
    {
      this.departmentService.updateDepartment(this.department).subscribe(x => 
        {
          this.ref.close();
          this.toastrService.success('Update Successful');
        });
     
    }
    else
    {
      this.department.id ="00000000-0000-0000-0000-000000000000";
      this.departmentService.saveDepartment(this.department).subscribe(x => 
      {
        this.ref.close();
        this.toastrService.success('Create Successful');
      });
    }
    
  }

  ngOnInit()
  {
  }
  
}
