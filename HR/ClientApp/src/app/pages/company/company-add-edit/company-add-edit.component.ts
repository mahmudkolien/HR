import { Component, OnInit, Input } from '@angular/core';
import { ISaveCompany } from '../shared/company.model';
import { CompanyService } from '../shared/company.service';
import { NbDialogRef, NbToastrService } from '@nebular/theme';

@Component({
  selector: 'app-company-add-edit',
  templateUrl: './company-add-edit.component.html',
  styleUrls: ['./company-add-edit.component.scss']
})
export class CompanyAddEditComponent implements OnInit {
@Input() company : ISaveCompany={
  id:'',
  companyName :'',
  address :'',
  phone :'',
  fax :'',
  email:'',
  contactPerson:'',
  contactPersonEmail:'',
  contactPersonPhone:'',
  fiscalYearStart:''
}
@Input() months:any[];
  constructor(protected ref: NbDialogRef<CompanyAddEditComponent>,private companyService: CompanyService,private toastrService: NbToastrService) {

   }

  ngOnInit() 
  {
    this.companyService.getMonth().subscribe(months=>{this.months=months;});
    
  }
  onSubmit()
  {
    if(this.company.id)
    {
      //console.log(this.company);
      this.companyService.updateCompany(this.company).subscribe(x => 
        {
          console.log(x);
          this.ref.close();
          this.toastrService.success('Update Successful');
        });
     
    }
    else
    {
      this.company.id ="00000000-0000-0000-0000-000000000000";
      this.companyService.saveCompany(this.company).subscribe(x => 
      {
        
        this.ref.close();
        this.toastrService.success('Create Successful');
      });
    }
  }

}
