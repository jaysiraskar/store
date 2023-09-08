import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrdersService } from '../orders.service';
import { IOrder } from 'src/app/shared/models/order';

@Component({
  selector: 'app-order-detailed',
  templateUrl: './order-detailed.component.html',
  styleUrls: ['./order-detailed.component.scss'],
})
export class OrderDetailedComponent implements OnInit {
  order!: IOrder;

  constructor(
    private route: ActivatedRoute,
    private breadCrumbService: BreadcrumbService,
    private ordersService: OrdersService
  ) {
    this.breadCrumbService.set('@OrderDetailed', '');
  }

  ngOnInit(): void {
    this.ordersService
      .getOrderDetailed(+this.route.snapshot.paramMap.get('id')!)
      .subscribe({
        next: (order: Object) => {
          this.order = order as IOrder;
        },
        error: (error: any) => {
          console.error(error);
        },
      });
  }
}
