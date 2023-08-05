import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {setTheme} from "ngx-bootstrap/utils"


import { BasketService } from './basket/services/basket.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';

  constructor(private basketService:BasketService){
    setTheme("bs5");
  }
  ngOnInit(): void {
    // this.http.get<Pagination<Product>>("http://localhost:5290/api/Products").subscribe(a=>{
    //   this.products = a.data;
    // })
    const basketId = localStorage.getItem("basket_id");
    if(basketId){
    this.basketService.getBasket(basketId)
    }

  }
}
