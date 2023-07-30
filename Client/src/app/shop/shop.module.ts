import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './components/shop/shop.component';
import { ProductItemComponent } from './components/product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ShopDetailsComponent } from './components/shop-details/shop-details.component';
import { RouterModule, Routes } from '@angular/router';


const router:Routes = [
  {path:"", component:ShopComponent},
  {path:":id", component:ShopDetailsComponent},
]
@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    ShopDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(router)
  ],

})
export class ShopModule { }
