import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BranchListComponent } from '../branch-list/branch-list.component';
import { BranchService } from './branch.service';

@NgModule({
  declarations: [
    BranchListComponent
   
  ],
  imports: [
    CommonModule,

  ]
})
export class BranchModule { }
