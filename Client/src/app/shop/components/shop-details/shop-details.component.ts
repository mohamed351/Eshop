import { Component, OnInit } from '@angular/core';
import {ShopService} from "../../services/shop.service";
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-shop-details',
  templateUrl: './shop-details.component.html',
  styleUrls: ['./shop-details.component.css']
})
export class ShopDetailsComponent implements OnInit {
  product?:Product;
  constructor(private shopService:ShopService, private activeRouter:ActivatedRoute) { }

  ngOnInit(): void {
    this.getProduct();
  }
  getProduct(){
    const id = this.activeRouter.snapshot.paramMap.get("id");
    if(id){
      this.shopService.getProduct(+id).subscribe(data=>{

        this.product = data;
      })
    }
  }

}
