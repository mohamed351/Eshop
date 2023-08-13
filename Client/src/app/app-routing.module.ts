import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { ShopComponent } from './shop/components/shop/shop.component';
import { ShopDetailsComponent } from './shop/components/shop-details/shop-details.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {path:"", loadChildren:()=> import("./home/home.module").then(c=> c.HomeModule) , data: {breadcrumb:"Home"}},
   {path:"errors", loadChildren:()=> import("./core/core.module").then(c=> c.CoreModule)},
  {path:"shop", loadChildren:()=> import("./shop/shop.module").then(c=> c.ShopModule)},
  {path:"basket", loadChildren:()=> import("./basket/basket.module").then(c=> c.BasketModule)},
  {path:"account", loadChildren:()=> import("./account/account.module").then(c=> c.AccountModule)},
  {path:"checkout", canActivate:[AuthGuard] , loadChildren:()=> import("./checkout/checkout.module").then(c=> c.CheckoutModule)},
  {path:"**",redirectTo:"", pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
