import { Config } from './../../../shared/config';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  developerCompanyFullName: string = '';
  currentDate: any;

  constructor(private config: Config) { }

  ngOnInit() {
    this.developerCompanyFullName = this.config.developerCompanyFullName;
    this.currentDate = new Date();
  }

}
