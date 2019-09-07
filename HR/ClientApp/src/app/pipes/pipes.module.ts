import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupByPipe } from './group-by.pipe';
import { ReplaceWithPipe } from './replace-with.pipe';

@NgModule({
  declarations: [
    GroupByPipe,
    ReplaceWithPipe,
  ],
  imports: [
    CommonModule,
  ],
  exports: [
    GroupByPipe,
    ReplaceWithPipe,
  ],
})
export class PipesModule { }
