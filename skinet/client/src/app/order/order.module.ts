import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './orders.component';
import { OrderRoutingModule } from './order-routing.module';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [OrdersComponent, OrderDetailComponent],
  imports: [
    CommonModule,
    OrderRoutingModule,
    SharedModule
  ],
  exports:[]
})
export class OrderModule { }
