import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BranchListComponent } from '../branch-list/branch-list.component';
import { BranchService } from './branch.service';
import { NbIconModule, NbDialogModule, NbCheckboxModule, NbCardModule, NbButtonModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { BranchAddEditComponent } from '../branch-add-edit/branch-add-edit.component';

@NgModule({
  declarations: [
    BranchListComponent,
    BranchAddEditComponent
   
  ],
  imports: [
    CommonModule,
    NbButtonModule,
    NbCardModule,
    NbCheckboxModule,
    NbDialogModule,
    FormsModule,
    NbIconModule

  ],providers: [
    BranchService
  ],
  entryComponents: [
    BranchAddEditComponent,
  ],
})
export class BranchModule { }
