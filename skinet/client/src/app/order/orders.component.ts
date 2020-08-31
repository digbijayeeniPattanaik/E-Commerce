import { Component, OnInit } from '@angular/core';
import { IOrder } from '../shared/models/order';
import {OrderService} from './order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: IOrder[];
  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders(): void {
    this.orderService.getOrders().subscribe(
      (response) => {
        this.orders = response;
        console.log(response);
      },
      (error) => {
        console.error(error);
      }
    );
  }


}
