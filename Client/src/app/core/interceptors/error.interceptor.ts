import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { NavigationExtras, Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router:Router, private  toaster:ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(catchError((error:HttpErrorResponse)=>{
      if(error){
        if(error.status == 400){
        if(error.error){
          if(error.error.errors){
            throw error.error;
          }
          else{
            this.toaster.error(error.error.message,error.status.toString())
          }

        }
        }

        if(error.status === 404){
          this.router.navigateByUrl("/errors/not-found");
        }
        if(error.status == 401){
          this.toaster.error("401","UnAuthorized");
        }
        else if (error.status == 500){
          const navigationExtra:NavigationExtras = {state : {error: error.error}}
          this.router.navigateByUrl("/errors/server-error",navigationExtra);
        }
      }
      return throwError(()=> new Error(error.message));
    }));
  }
}
