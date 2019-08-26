import { Component, OnInit,TemplateRef } from '@angular/core';
import { CompanyService } from '../shared/company.service';
import { ICompany, ISaveCompany } from '../shared/company.model';
import { CompanyAddEditComponent } from '../company-add-edit/company-add-edit.component';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { ThrowStmt } from '@angular/compiler';
import { IQueryResult } from '../../shared/query-result.model';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.scss']
})
export class CompanyListComponent implements OnInit {

  queryResult: IQueryResult;
  months : any[];
  saveCompany : ISaveCompany={
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
  constructor(private companyService : CompanyService,private dialogService: NbDialogService,private toastrService: NbToastrService) {
    this.initiateQueryResult();
   }

  ngOnInit() 
  {
    this.MapCompaniesData();
    this.initiateQueryResult();
    this.companyService.getMonth().subscribe(months=>{this.months=months;});
  }
  open()
   {
      this.dialogService.open(CompanyAddEditComponent, {
        context: { },
      }).onClose.subscribe(data => {
        this.MapCompaniesData();
      });
  }
  getMonthName(intMonth)
  {
    return this.months? this.months.find(s=>s.value==intMonth).text: intMonth;
  }
  edit(company)
  {
 
    this.saveCompany.id = company.id;
    this.saveCompany.companyName = company.companyName;
    this.saveCompany.address = company.address;
    this.saveCompany.phone= company.phone;
    this.saveCompany.fax = company.fax;
    this.saveCompany.email = company.email;
    this.saveCompany.contactPerson = company.contactPerson;
    this.saveCompany.contactPersonEmail = company.contactPersonEmail;
    this.saveCompany.contactPersonPhone= company.contactPersonPhone;
    this.saveCompany.fiscalYearStart = company.fiscalYearStart;
  
    this.dialogService.open(CompanyAddEditComponent, {
      context: {company: this.saveCompany},
    }).onClose.subscribe(data => {
      this.MapCompaniesData();
    });
  }
  delete(id)
  {
    if(confirm("Are you want to delete?"))
    {
      this.companyService.deleteCompany(id).subscribe(data=>{
        this.toastrService.success('Delete Successful');
       this.MapCompaniesData();
      });
    }
  }
  MapCompaniesData(){
    this.companyService.getCompanies().subscribe(data => this.queryResult = <IQueryResult>data)
  }
  initiateQueryResult() {
    this.queryResult = {
      totalItems: 0,
      items: [],
    };
  }
}
