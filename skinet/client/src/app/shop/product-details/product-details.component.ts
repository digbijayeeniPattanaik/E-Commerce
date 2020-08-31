import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { IProduct } from 'src/app/shared/models/product';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  quantity = 1;

  constructor(
    private shopService: ShopService,
    private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private basketService: BasketService
  ) {
    this.bcService.set('@productDetails', '');
  }

  ngOnInit(): void {
    this.loadProduct();
  }

addItemToBasket() {
  this.basketService.addItemToBasket(this.product, this.quantity);
}

incrementQuantity(){
  this.quantity++;
}

decrementQuantity(){
  if(this.quantity > 1){
  this.quantity--;
}
}


  loadProduct() {
    //name mentioned in the routing module
    this.shopService
      .getProduct(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (response) => {
          this.product = response;
          this.bcService.set('@productDetails', this.product.name);
        },
        (error) => {
          console.error(error);
        }
      );
  }
}
