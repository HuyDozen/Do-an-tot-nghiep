import { Component,OnInit } from '@angular/core';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-list-order',
  templateUrl: './list-order.component.html',
  styleUrls: ['./list-order.component.css']
})
export class ListOrderComponent implements OnInit{
  detailOrder

  constructor(private order:OrderService){

  }
  ngOnInit(): void {
    this.order.getAllOrderDetail().subscribe(prod =>
      {
        this.detailOrder = prod
        console.log(this.detailOrder);
        
      })
  }
}
