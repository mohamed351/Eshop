import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { OrderTotalsComponent } from './order-totals/order-totals.component';
import { TextInputComponent } from './text-input/text-input.component'



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    TextInputComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    PaginationModule.forRoot(),
    ReactiveFormsModule


  ],
  exports:[PaginationModule, PagingHeaderComponent, OrderTotalsComponent, TextInputComponent]

})
export class SharedModule { }
