import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import {FormsModule} from "@angular/forms"



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    PaginationModule.forRoot()


  ],
  exports:[PaginationModule, PagingHeaderComponent]

})
export class SharedModule { }
