import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './components/basket/basket.component';
import {RouterModule, Routes} from "@angular/router";
import { SharedModule } from '../shared/shared.module';

const routes:Routes = [
  {path:"", component:BasketComponent}
]

@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class BasketModule { }
