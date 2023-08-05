import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './components/basket/basket.component';
import {RouterModule, Routes} from "@angular/router";

const routes:Routes = [
  {path:"", component:BasketComponent}
]

@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class BasketModule { }
