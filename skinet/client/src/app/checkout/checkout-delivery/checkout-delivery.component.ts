import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CheckoutService } from '../checkout.service';
import { IDeliveryMethod } from 'src/app/shared/models/deliveryMethod';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkOutForm : FormGroup;
  deliveryMethods: IDeliveryMethod[];
  constructor(private checkOutService : CheckoutService) { }

  ngOnInit(): void {
    this.checkOutService.getDeliveryMethod().subscribe((dm: IDeliveryMethod[]) => {
      this.deliveryMethods = dm;
    }, error => {
      console.log(error);
    });
  }

}
