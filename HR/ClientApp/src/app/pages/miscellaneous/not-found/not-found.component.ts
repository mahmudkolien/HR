import { Component, OnInit } from '@angular/core';
import { NbMenuService } from '@nebular/theme';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  // tslint:disable-next-line:trailing-comma
  styleUrls: ['./not-found.component.scss']
})
export class NotFoundComponent {

  constructor(private menuService: NbMenuService) {
  }

  goToHome() {
    this.menuService.navigateHome();
  }

}
