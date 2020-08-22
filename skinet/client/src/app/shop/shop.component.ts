import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
products: IProduct[];
brand: IBrand[];
productType: IType[];
brandIdSelected = 0;
typeIdSelected = 0;
pageIndex: number;
totalCount: number;
pageSize: number;
sortSelected = 'name';
sortOptions = [
  {name: 'Alphabetical', value: 'name'},
  {name: 'Price: Low to High', value: 'priceAsc'},
  {name: 'Price: High to Low', value: 'priceDesc'}
];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
  this.getProducts();
  this.getBrand();
  this.getProductType();
  }

  getProducts(): void  {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected).subscribe(response => {
      this.products = response.data;
      this.pageIndex = response.pageIndex;
      this.totalCount = response.count;
      this.pageSize = response.pageSize * this.pageIndex;
      }, error => {
        console.error(error);
      });
  }

  getBrand(): void {
    this.shopService.getBrand().subscribe(response => {
      this.brand = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.error(error);
    });
  }

  getProductType(): void  {
    this.shopService.getProductType().subscribe(response => {
      this.productType = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.error(error);
    });
  }

  onBrandSelected(brandId: number): void{
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  onTypeIdSelected(typeId: number): void{
    this.typeIdSelected = typeId;
    this.getProducts();
  }

  onSortSelected(sortBy: string): void{
    this.sortSelected = sortBy;
    this.getProducts();
  }
}
