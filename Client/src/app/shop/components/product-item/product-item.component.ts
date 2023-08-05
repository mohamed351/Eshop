import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/services/basket.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() product?:Product;
  constructor(private basketSerivce:BasketService) { }

  ngOnInit(): void {
  }
  addProductToItem(){
    this.product && this.basketSerivce.addItemToBasket(this.product)

  }

}
