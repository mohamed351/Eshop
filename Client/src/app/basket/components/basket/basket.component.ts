import { Component, OnInit } from '@angular/core';
import { BasketService } from '../../services/basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  constructor(public basket:BasketService) { }

  ngOnInit(): void {
  }
  increaseQuantity(productId:number){
    this.basket.IncreaseQuantity(productId,1);
  }
  decreseQuantity(productId:number){
    this.basket.DecreseQuantity(productId,1);
  }
  removeBasket(productId:number){
    this.basket.RemoveItem(productId);
  }


}
