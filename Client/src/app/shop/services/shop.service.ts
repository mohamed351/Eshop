import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from 'src/app/models/brand';
import { Pagination } from 'src/app/models/pagination';
import { Product } from 'src/app/models/product';
import { ProductType } from 'src/app/models/productType';
import { ShopParams } from 'src/app/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private  baseURL = "http://localhost:5290";
  constructor(private http:HttpClient) {

  }
  getProducts({selectedBrandID, selectedTypeID, sortData, count,pageIndex,pageSize, search}:ShopParams){
    let params = new HttpParams();
    if(selectedBrandID) params = params.append("BrandID",selectedBrandID);
    if(selectedTypeID) params = params.append("TypeID",selectedTypeID);
    if(sortData) params = params.append("Sort",sortData)
   if(pageIndex) params = params.append("PageIndex",pageIndex)
   if(pageSize) params = params.append("pageSize",pageSize)
   if(search) params = params.append("search",search)

    return this.http.get<Pagination<Product>>(`${this.baseURL}/api/Products`,{params});
  }
  getProduct(id:number){
    return this.http.get<Product>(`${this.baseURL}/api/Products/${id}`);
  }
  getProductTypes(){
    return this.http.get<ProductType[]>(`${this.baseURL}/api/Products/types`);
  }
  getBrands(){
    return this.http.get<Brand[]>(`${this.baseURL}/api/Products/brand`);
  }
}
