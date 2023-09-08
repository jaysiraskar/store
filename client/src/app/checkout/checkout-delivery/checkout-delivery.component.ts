import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CheckoutService } from '../checkout.service';
import { IDeliveryMethod } from 'src/app/shared/models/deliveryMethod';
import { BasketService } from 'src/app/basket/basket.service';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkoutForm!: FormGroup;
  deliveryMethods!: IDeliveryMethod[];

  constructor(private checkoutService: CheckoutService, private basketService: BasketService) { }

  ngOnInit() {
    this.checkoutService.getDeliveryMethods().pipe(
      catchError((error: any) => {
        console.error(error);
        return throwError(error);
      })
    ).subscribe((dm: IDeliveryMethod[]) => {
      this.deliveryMethods = dm;
    });
  }

  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.basketService.setShippingPrice(deliveryMethod);
  }

}
