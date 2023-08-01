import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarComponent} from "./navbar/navbar.component";
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { TestingErrorComponent } from './testing-error/testing-error.component';
import { ToastrModule } from 'ngx-toastr';
import { SectionHeaderComponent } from './section-header/section-header.component';
import {BreadcrumbModule} from "xng-breadcrumb";
const routes:Routes =[
  {path:"", component:TestingErrorComponent},
    {path:"not-found", component:NotFoundComponent},
    {path:"server-error" , component:ServerErrorComponent}

]

@NgModule({
  declarations: [NavbarComponent, NotFoundComponent, ServerErrorComponent, TestingErrorComponent, SectionHeaderComponent ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ToastrModule.forRoot({
      positionClass:"toast-bottom-right",
      preventDuplicates:true,
    }),
    BreadcrumbModule,


  ],
  exports:[
    NavbarComponent,
    SectionHeaderComponent
  ]
})
export class CoreModule { }
