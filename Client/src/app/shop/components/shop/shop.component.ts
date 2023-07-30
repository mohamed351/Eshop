import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import {ShopService} from "../../services/shop.service";
import { Product } from 'src/app/models/product';
import { Brand } from 'src/app/models/brand';
import { ProductType } from 'src/app/models/productType';
import { ShopParams } from 'src/app/models/shopParams';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
   @ViewChild("search")  search:ElementRef<any> |undefined;
  products:Product[] = [];
  brands:Brand[] = [];
  types:ProductType[] =[];
  shopingParams:ShopParams = new ShopParams()
  selectedBrandID =0;
  selectedTypeID =0;
  sortData:string = "";


   sortOptions =[
    {value:"name", text:"Alphabetical"},
    {value:"priceAsc", text:"Low to High" },
   {value:"priceDesc", text:"high to Low" }
  ]
  constructor(private shopingService:ShopService) { }

  ngOnInit(): void {
    this.getProduct();
    this.getBrands();
    this.getType();
  }
  getProduct(){
    this.shopingService.getProducts(this.shopingParams).subscribe(data =>{
      this.products = data.data;
      this.shopingParams.pageIndex = data.pageIndex;
      this.shopingParams.pageSize = data.pageSize;
      this.shopingParams.count = data.count;
    })
  }
  getBrands(){
    this.shopingService.getBrands().subscribe(data =>{
      this.brands = [ {id:0, name:"All"}, ...data];
    })
  }
  getType(){
    this.shopingService.getProductTypes().subscribe(data =>{
      this.types = [{id:0,name:"All"}, ...data];
    })
  }
  onBrandSelected(brandId:number){
    this.shopingParams.pageIndex = 1;
    this.shopingParams.selectedBrandID = brandId;
    this.getProduct();
  }
  onProductTypeSelected(productTypeID:number){
    this.shopingParams.pageIndex = 1;
    this.shopingParams.selectedTypeID = productTypeID;
    this.getProduct();
  }
  onSortChange(data:any){
    this.shopingParams.sortData= data.target.value;
      this.getProduct();
  }
  onPageChanges(data:PageChangedEvent){
    this.shopingParams.pageIndex = data.page;
    this.getProduct();
  }
  onSearch(){
    this.shopingParams.search = this.search?.nativeElement.value;
    this.getProduct();
  }
  OnReset(){
    if(this.search?.nativeElement){
      (this.search?.nativeElement).value = ""
      this.shopingParams.search = "";
      this.getProduct();
    }
  }


}
