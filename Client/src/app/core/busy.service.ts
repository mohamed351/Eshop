import { Injectable } from '@angular/core';
import {NgxSpinnerService} from "ngx-spinner";
@Injectable({
  providedIn: 'root'
})
export class BusyService {

  constructor(private spinner:NgxSpinnerService ) { }

  busy(){
    this.spinner.show(undefined,{
      bdColor:"rgba(255,255,255,0.7)",
      color:"#000",
      type:"timer",
    })
  }
  idle(){
    this.spinner.hide();

  }
}
