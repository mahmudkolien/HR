import { FormsModule,NgForm } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentService } from './/department.service';
import {DepartmentComponent} from '../department.component'
import { NbDialogService, NbButtonModule, NbCardModule, NbCheckboxModule, NbDialogModule } from '@nebular/theme';
import { DeparmentAddComponent } from '../deparment-add/deparment-add.component';
import { ToasterService } from 'angular2-toaster';




@NgModule({
  declarations: [
    DepartmentComponent,
    DeparmentAddComponent,
 
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
    DepartmentService,
    NbDialogService,
    ToasterService
  ],
  entryComponents: [
    DeparmentAddComponent,
  ],
})
export class DepartmentModule { }