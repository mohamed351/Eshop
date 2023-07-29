import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {setTheme} from "ngx-bootstrap/utils"
import { Pagination } from './models/pagination';
import { Product } from './models/product';
import {ShopService} from "./shop/services/shop.service";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';

  constructor(private shopingService:ShopService){
    setTheme("bs5");
  }
  ngOnInit(): void {
    // this.http.get<Pagination<Product>>("http://localhost:5290/api/Products").subscribe(a=>{
    //   this.products = a.data;
    // })

  }
}
