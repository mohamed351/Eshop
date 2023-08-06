import { Component, OnInit } from '@angular/core';
import {ShopService} from "../../services/shop.service";
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/services/basket.service';

@Component({
  selector: 'app-shop-details',
  templateUrl: './shop-details.component.html',
  styleUrls: ['./shop-details.component.css']
})
export class ShopDetailsComponent implements OnInit {
  product?:Product;
  quantity:number = 0;
  constructor(private shopService:ShopService,
    private activeRouter:ActivatedRoute,
    private bsService:BreadcrumbService,
    private basketSevice:BasketService) {
      this.bsService.set("@productDetails"," ");
    }

  ngOnInit(): void {
    this.getProduct();
    this.basketSevice.basketService$.subscribe(c=>{
      const id =  this.activeRouter.snapshot.paramMap.get("id");
      if(id){
       const basket = c?.items.find(c=> c.id == +id)
       this.quantity = basket?.quantity ?? 0;
      }
    })
  }
  getProduct(){
    const id = this.activeRouter.snapshot.paramMap.get("id");
    if(id){
      this.shopService.getProduct(+id).subscribe(data=>{
        this.bsService.set("@productDetails",data.name);
        this.product = data;
      })
    }
  }
  IncreseQuantity(){
    this.quantity++;
  }

  DecreseQuantity(){
    this.quantity--;
  }
  SetQuantity(){
    if(this.product){

     this.basketSevice.SetQuantity(this.product,this.quantity);
    }
  }

}
