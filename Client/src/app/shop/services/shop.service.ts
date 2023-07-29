import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from 'src/app/models/pagination';
import { Product } from 'src/app/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private  baseURL = "http://localhost:5290";
  constructor(private http:HttpClient) {

  }
  getProducts(){
    return this.http.get<Pagination<Product>>(`${this.baseURL}/api/Products`);
  }
}
