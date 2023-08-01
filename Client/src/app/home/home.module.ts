import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule, Routes } from '@angular/router';


const routers:Routes = [
  {path :"", component:HomeComponent , data:{breadcrumb:"Home" }},

]

@NgModule({
  declarations: [
    HomeComponent,

  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routers)
  ],

})
export class HomeModule { }
