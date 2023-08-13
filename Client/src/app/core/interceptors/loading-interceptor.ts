import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, delay, finalize } from 'rxjs';
import { BusyService } from '../busy.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private busy:BusyService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if(!request.url.includes("emailexists")){
      this.busy.busy();
    }

    return next.handle(request).pipe(delay(1000),finalize(()=>{
      this.busy.idle();
    }));
  }
}
