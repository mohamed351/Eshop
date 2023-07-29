import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from 'src/app/models/brand';
import { Pagination } from 'src/app/models/pagination';
import { Product } from 'src/app/models/product';
import { ProductType } from 'src/app/models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private  baseURL = "http://localhost:5290";
  constructor(private http:HttpClient) {

  }
  getProducts(brandId?:number,typeId?:number, sort?:string){
    let params = new HttpParams();
    if(brandId) params = params.append("BrandID",brandId);
    if(typeId) params = params.append("TypeID",typeId);
    if(sort) params = params.append("Sort",sort)

    return this.http.get<Pagination<Product>>(`${this.baseURL}/api/Products`,{params});
  }
  getProductTypes(){
    return this.http.get<ProductType[]>(`${this.baseURL}/api/Products/types`);
  }
  getBrands(){
    return this.http.get<Brand[]>(`${this.baseURL}/api/Products/brand`);
  }
}
