import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { ShopComponent } from './shop/components/shop/shop.component';
import { ShopDetailsComponent } from './shop/components/shop-details/shop-details.component';

const routes: Routes = [
  {path:"", loadChildren:()=> import("./home/home.module").then(c=> c.HomeModule)},
  {path:"shop", loadChildren:()=> import("./shop/shop.module").then(c=> c.ShopModule)},
  {path:"**",redirectTo:"", pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
