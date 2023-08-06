import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Basket, BasketItem, BasketTotal } from 'src/app/models/basket';
import { Product } from 'src/app/models/product';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket | null>(null);
  private basetTotalSource = new BehaviorSubject<BasketTotal|null>(null);
  basketService$ = this.basketSource.asObservable();
  basketTotalSource$ = this.basetTotalSource.asObservable();

  constructor(private http:HttpClient) { }
  getBasket(id:string){
    return this.http.get<Basket>(`${environment.apiUrl}Basket/${id}`).subscribe({
      next:response =>{
        this.basketSource.next(response);
        this.calculateTotals();
      }
    })
  }
  setBasket(basket:Basket){
    return this.http.post<Basket>(`${environment.apiUrl}Basket`,basket).subscribe({
      next:basket => this.basketSource.next(basket)
    })
  }
  getCurrentBasketValue(){
    return this.basketSource.value;
  }
  addItemToBasket(item:Product,quantity =1){
    const itemToAdd = this.mapProductItemToBasetItem(item);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items,itemToAdd,1)
    this.setBasket(basket);
    this.calculateTotals();
  }
  IncreaseQuantity(productId:number,quantity:number){
    const basket = this.getCurrentBasketValue();
    if(basket){
    const item = basket?.items.find(a=> a.id == productId);
    if(item){
      item.quantity = item.quantity +quantity;
      this.setBasket(basket);
      this.calculateTotals();
    }
  }

  }
  DecreseQuantity(productId:number,quantity:number){
    const basket = this.getCurrentBasketValue();
    if(basket){
    const item = basket?.items.find(a=> a.id == productId);
    if(item){
      item.quantity = item.quantity -quantity;
      if(item.quantity <= 0){
        basket.items=   basket.items.filter(a=> a.id !== productId);
      }
      this.setBasket(basket);
      this.calculateTotals();
    }
  }

  }
  SetQuantity(product:Product,quantity:number){
    const basket = this.getCurrentBasketValue();
    if(basket){
    const item = basket.items.find(a=> a.id == product.id);

    if(item){
      item.quantity = quantity;
      this.setBasket(basket);
      this.calculateTotals();
    }
    else{
      const newItem= this.mapProductItemToBasetItem(product);
      newItem.quantity = quantity;
      basket.items.push(newItem);
      this.setBasket(basket);
      this.calculateTotals();

    }
  }


  }

  RemoveItem(productId:number){
    const basket = this.getCurrentBasketValue();
    if(basket){
     basket.items = basket?.items.filter(a=> a.id !== productId);
     this.setBasket(basket);
     this.calculateTotals();
    }

  }
  private addOrUpdateItem(items:BasketItem[], itemToAdd:BasketItem, quantity:number):BasketItem[]{
    const item = items.find(a=> a.id === itemToAdd.id);
    if(item){
      item.quantity+= quantity
    }
    else{
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    }
    return items
  }
  private createBasket(){
    const basket = new Basket();
    localStorage.setItem("basket_id",basket.id);
    return basket;
  }
private mapProductItemToBasetItem(item:Product):BasketItem{
  return {
    id:item.id,
    productName:item.name,
    brand:item.productBrand,
    pictureUrl:item.pictureUrl,
    price:item.price,
    quantity:0,
    type:item.productType
  }
}

private calculateTotals(){
  const basket = this.getCurrentBasketValue();
  if(!basket){
    return ;
  }
  const shipping =0;
  const subTotal = basket.items.reduce((accumator,current)=>{
    return (current.price * current.quantity) + accumator;
  },0)
  const total = shipping+subTotal;
  this.basetTotalSource.next({shipping:shipping,subtotal:subTotal, total});
}
}
