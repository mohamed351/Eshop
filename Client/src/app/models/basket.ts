import { createId } from '@paralleldrive/cuid2';

export interface IBasket {
  id:    string;
  items: BasketItem[];
}


export interface BasketItem {
  id:          number;
  productName: string;
  price:       number;
  quantity:    number;
  pictureUrl:  string;
  brand:       string;
  type:        string;
}
export class Basket implements IBasket{
  id: string = createId();
  items: BasketItem[] = [];

}
export interface BasketTotal{
  shipping:number;
  subtotal:number;
  total:number;
}
