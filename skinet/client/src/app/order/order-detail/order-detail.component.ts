import { Component, OnInit } from '@angular/core';
import {OrderService} from '../order.service';
import { IOrder } from 'src/app/shared/models/order';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {
  order: IOrder;
  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
  }


  getOrder(id: number) {
    this.orderService.getOrder(id).subscribe(
      (response) => {
        this.order = response;
        console.log(response);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
