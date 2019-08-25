import { ErrorHandler, Inject, NgZone, isDevMode } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

export class AppErrorHandler implements ErrorHandler {

    constructor(private ngZone: NgZone, @Inject(NbToastrService) private toastrService: NbToastrService) {
    }

    handleError(error: any): void {


      if (error instanceof HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
          // A client-side or network error occurred. Handle it accordingly.
          console.error('An error occurred:', error.error.message);
        } else {
          // The backend returned an unsuccessful response code.
          // The response body may contain clues as to what went wrong,
          console.error(
            `Backend returned code ${error.status}, ` +
            `body was: ${error.error}`);
        }
      } else {
        console.error('some thing else happened:', error.message);
      }



      this.ngZone.run(() => {
        this.toastrService.danger(error.message, 'Error!');
      });

      if (!isDevMode()) {
        console.error(error);
      } else {
        throw error;
      }

    }
}
