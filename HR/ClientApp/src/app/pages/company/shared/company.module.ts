import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompanyListComponent } from '../company-list/company-list.component';
import { ToasterService } from 'angular2-toaster';
import { NbDialogService, NbButtonModule, NbCardModule, NbCheckboxModule, NbDialogModule } from '@nebular/theme';
import { CompanyService } from './company.service';
import { CompanyAddEditComponent } from '../company-add-edit/company-add-edit.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [

    CompanyListComponent,
    CompanyAddEditComponent
  ],
  imports: [
    CommonModule,
    NbButtonModule,
    NbCardModule,
    NbCheckboxModule,
    NbDialogModule,
    FormsModule,
    
  ],
  providers: [
    CompanyService,
    NbDialogService,
    ToasterService
  ],
  entryComponents: [
    CompanyAddEditComponent,
  ],
})
export class CompanyModule { }
