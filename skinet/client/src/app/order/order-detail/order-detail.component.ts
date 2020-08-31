import { Component, OnInit } from '@angular/core';
import { OrderService } from '../order.service';
import { IOrder } from 'src/app/shared/models/order';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss'],
})
export class OrderDetailComponent implements OnInit {
  order: IOrder;
  constructor(
    private orderService: OrderService,
    private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService
  ) {
    this.bcService.set('@OrderDetailed', '');
  }

  ngOnInit(): void {
    this.getOrder();
  }

  getOrder() {
    this.orderService
      .getOrder(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (response: IOrder) => {
          this.order = response;
          this.bcService.set(
            '@OrderDetailed',
            'Order#' + this.order.id + ' - ' + this.order.status
          );
        },
        (error) => {
          console.error(error);
        }
      );
  }
}
