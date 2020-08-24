import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { IProduct } from 'src/app/shared/models/product';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct(){
    //name mentioned in the routing module
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe((response) => {
      this.product = response;
      this.bcService.set('@productDetails',this.product.name)
    },
    (error) => {
      console.error(error);
    })
  }
}
