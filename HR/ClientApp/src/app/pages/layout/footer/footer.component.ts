import { Config } from './../../../shared/config';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  companyFullName: string = '';
  currentDate: any;

  constructor(private config: Config) { }

  ngOnInit() {
    this.companyFullName = this.config.companyFullName;
    this.currentDate = new Date();
  }

}
