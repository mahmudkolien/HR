import { Shared } from './../../shared/shared';
import { messages } from './../../../ngx-pages/extra-components/chat/messages';

import { Component, OnInit, ChangeDetectorRef, ErrorHandler, ViewChild, ElementRef } from '@angular/core';
import { ISaveUser, IUser } from '../shared/user.model';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { UserService } from '../shared/user.service';
import { NbToastrService } from '@nebular/theme';
import { throwError } from 'rxjs';
import { IQueryResult } from '../../shared/query-result.model';
import { switchMap } from 'rxjs/operators';
import { IUserRole } from '../../user-role/shared/user-role.model';
import { UserRoleService } from '../../user-role/shared/user-role.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  @ViewChild('inputFile', { static: true }) inputFile: ElementRef;
  user: ISaveUser;
  userRoles: IUserRole[] = [];
  submitted: boolean = false;
  errors: string[] = [];
  showMessages: any = { success: false, error: false };
  messages: string[] = [];
  imageError: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shared: Shared,
    private userService: UserService,
    private userRoleService: UserRoleService,
    private toastrService: NbToastrService) {
      this.resetForm();
    }

  ngOnInit() {
    this.userRoleService.getUserRoles().subscribe(data => {
      this.userRoles = (<IQueryResult>data).items;
    });
    this.populateUser();
  }

  onFormSubmit(form) {
    if (this.user.id) {
      this.userService.update(this.user).subscribe(
        data => {
          this.toastrService.success('User has been successfully updated.', 'Successfully updated.');
          this.resetForm(form);
          this.populateUser();
        });
    } else {
      this.userService.create(this.user).subscribe(
        data => {
          this.toastrService.success('User has been successfully added.', 'Successfully added.');
          this.resetForm(form);
        });
    }
  }

  resetForm(form?) {
    if (form)
      form.resetForm();

    this.user = {
      id: '',
      fullName: '',
      userName: '',
      email: '',
      mobile: '',
      gender: '',
      address: '',
      userRoleId: '',
      isDeleted: false,
      imageFile: '',
      inputFile: null,
    };
  }

  populateUser() {
    // get observable with user
    // const user$ = this.route.paramMap.pipe(
    //   switchMap((params: ParamMap) =>
    //     this.userService.getUser(params.get('id'))),
    // );

    // get id
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.userService.getUser(id).subscribe(data => {
        this.setUser(<IUser>data);
      });
    }
  }

  setUser(user: IUser) {
    this.user = {
      id: user.id,
      fullName: user.fullName,
      userName: user.userName,
      email: user.email,
      mobile: user.mobile,
      gender: user.gender,
      address: user.address,
      userRoleId: user.userRole.id,
      isDeleted: user.isDeleted,
      imageFile: user.imageFile ? '/uploads/' + user.imageFile : '',
      inputFile: null,
    };
  }

  // for Image --- start
  onChangeInputFile(event: any) {
    if (event.target.files && event.target.files[0]) {
      const reader = new FileReader();
      const file = event.target.files[0];
      if (!this.isValidImage(file)) return;
      this.user.inputFile = this.inputFile.nativeElement.files[0];
      reader.onload = (loadEvent: any) => {
        this.user.imageFile = loadEvent.target.result;
      };
      reader.readAsDataURL(file);
    } else {
      this.user.inputFile = null;
      this.user.imageFile = '';
    }
  }

  isValidImage(file) {
    const fileExt = '.' + file.name.split('.').pop().toLowerCase();
    if (!(this.shared.PhotoSettings.AcceptedFileTypes.indexOf(fileExt) > -1)) {
      this.imageError = 'Invalid file type.';
      this.user.inputFile = null;
      this.user.imageFile = '';
      return false;
    }
    if (file.size > this.shared.PhotoSettings.MaxBytes) {
      this.imageError = 'Max file size exceeded';
      this.user.inputFile = null;
      this.user.imageFile = '';
      return false;
    }
    this.imageError = '';
    return true;
  }

  onRemoveInputFile() {
    this.user.imageFile = '';
  }
  // for Image --- end

}
