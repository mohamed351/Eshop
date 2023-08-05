import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule, Routes } from '@angular/router';
import {CarouselModule} from "ngx-bootstrap/carousel";

const routers:Routes = [
  {path :"", component:HomeComponent , data:{breadcrumb:"Home" }},

]

@NgModule({
  declarations: [
    HomeComponent,

  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routers),
    CarouselModule
  ],

})
export class HomeModule { }
