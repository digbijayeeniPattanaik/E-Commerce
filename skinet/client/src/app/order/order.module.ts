import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './orders.component';
import { OrderRoutingModule } from './order-routing.module';



@NgModule({
  declarations: [OrdersComponent],
  imports: [
    CommonModule,
    OrderRoutingModule
  ],
  exports:[]
})
export class OrderModule { }
