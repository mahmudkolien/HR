import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MiscellaneousComponent } from './miscellaneous.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { MiscellaneousRoutingModule } from './miscellaneous-routing.module';
import { ThemeModule } from '../../@theme/theme.module';
import { NbCardModule, NbButtonModule } from '@nebular/theme';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
  declarations: [MiscellaneousComponent, NotFoundComponent, UnauthorizedComponent],
  imports: [
    ThemeModule,
    NbCardModule,
    NbButtonModule,
    MiscellaneousRoutingModule,
  ]
})
export class MiscellaneousModule { }
