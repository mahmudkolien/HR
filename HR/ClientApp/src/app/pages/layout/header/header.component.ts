import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { NbSidebarService, NbMenuService, NbThemeService, NbMediaBreakpointsService } from '@nebular/theme';
import { UserData } from '../../../@core/data/users';
import { LayoutService } from '../../../@core/utils';
import { takeUntil, map } from 'rxjs/operators';
import { AuthService } from '../../../auth/shared/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit, OnDestroy {

  private destroy$: Subject<void> = new Subject<void>();
  userPictureOnly: boolean = false;
  user: any;

  themes = [
    {
      value: 'default',
      name: 'Light',
    },
    {
      value: 'dark',
      name: 'Dark',
    },
    {
      value: 'cosmic',
      name: 'Cosmic',
    },
    {
      value: 'corporate',
      name: 'Corporate',
    },
  ];

  currentTheme = 'default';

  userMenu = [{ title: 'Login' }];

  constructor(private sidebarService: NbSidebarService,
              private menuService: NbMenuService,
              private themeService: NbThemeService,
              private userService: UserData,
              private layoutService: LayoutService,
              private breakpointService: NbMediaBreakpointsService,
              private authService: AuthService,
              private router: Router) {
  }

  ngOnInit() {
    this.currentTheme = this.themeService.currentTheme;

    this.userService.getUsers()
      .pipe(takeUntil(this.destroy$))
      .subscribe((users: any) => this.user = users.kate);

    const { xl } = this.breakpointService.getBreakpointsMap();
    this.themeService.onMediaQueryChange()
      .pipe(
        map(([, currentBreakpoint]) => currentBreakpoint.width < xl),
        takeUntil(this.destroy$),
      )
      .subscribe((isLessThanXl: boolean) => this.userPictureOnly = isLessThanXl);

    this.themeService.onThemeChange()
      .pipe(
        map(({ name }) => name),
        takeUntil(this.destroy$),
      )
      .subscribe(themeName => this.currentTheme = themeName);


      const user = this.authService.currentUserValue;
      if (user) {
        this.userMenu = [{ title: 'Profile' }, { title: 'Log out' }];
        this.user = {
          name: user.fullName,
          picture: (user.imageFile ? '/uploads/' + user.imageFile : '/assets/images/avatar.png'),
        };
      } else {
        this.user = {
          name: 'No User',
          picture: '/assets/images/avatar.png',
        };
      }

      this.menuService.onItemClick().subscribe(( event ) => {
        this.onItemSelection(event.item.title);
      });
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  changeTheme(themeName: string) {
    this.themeService.changeTheme(themeName);
  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, 'menu-sidebar');
    this.layoutService.changeLayoutSize();

    return false;
  }

  navigateHome() {
    this.menuService.navigateHome();
    return false;
  }

  onItemSelection( title ) {
    if ( title === 'Log out' ) {
      // tslint:disable-next-line:no-console
      console.log('Log out Clicked ');
      this.authService.logout();
    } else if ( title === 'Profile' ) {
      // tslint:disable-next-line:no-console
      console.log('Profile Clicked ');
    } else if ( title === 'Login' ) {
      // tslint:disable-next-line:no-console
      console.log('Login ');
      this.router.navigate(['/auth/login']);
    }
  }

}
