import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from './auth/shared/auth.service';
import { Router, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(
        private router: Router,
        private authService: AuthService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return <any>next.handle(request).pipe(catchError((err: HttpErrorResponse) => {
            if ([401, 403].indexOf(err.status) !== -1) {
                // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
                const currentUser = this.authService.currentUserValue;
                const isLoggedIn = currentUser && currentUser.token;
                if (!isLoggedIn) {
                    this.authService.logout();
                } else {
                    this.router.navigate(['/pages/miscellaneous/401']);
                }
            }

            // const error = err.error.message || err.statusText;
            return throwError(err);
        }));
    }
}
