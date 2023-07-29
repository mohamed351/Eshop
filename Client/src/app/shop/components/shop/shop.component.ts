import { Component, OnInit } from '@angular/core';
import {ShopService} from "../../services/shop.service";
import { Product } from 'src/app/models/product';
import { Brand } from 'src/app/models/brand';
import { ProductType } from 'src/app/models/productType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  products:Product[] = [];
  brands:Brand[] = [];
  types:ProductType[] =[];
  selectedBrandID =0;
  selectedTypeID =0;
  sortData:string = "";

  /**
   *
   *
   *   <option selected>Alphabetical</option>
   *  <option>Pice : high to Low</option>
          <option>Price : Low to high</option>

   */
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
    this.shopingService.getProducts(this.selectedBrandID,this.selectedTypeID, this.sortData).subscribe(data =>{
      this.products = data.data;
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
    this.selectedBrandID = brandId;
    this.getProduct();
  }
  onProductTypeSelected(productTypeID:number){
    this.selectedTypeID = productTypeID;
    this.getProduct();
  }
  onSortChange(data:any){
      this.sortData = data.target.value;
      this.getProduct();
  }


}
