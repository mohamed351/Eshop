import { Component, OnInit } from '@angular/core';
import {ShopService} from "../../services/shop.service";
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  products:Product[] = [];
  constructor(private shopingService:ShopService) { }

  ngOnInit(): void {
    this.shopingService.getProducts().subscribe(data =>{
      this.products = data.data;
    })
  }

}
