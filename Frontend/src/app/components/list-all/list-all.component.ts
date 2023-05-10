import { Component,OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';
import {faArrowAltCircleLeft,faArrowAltCircleRight} from '@fortawesome/free-solid-svg-icons'
import { map } from 'rxjs';

@Component({
  selector: 'app-list-all',
  templateUrl: './list-all.component.html',
  styleUrls: ['./list-all.component.css']
})
export class ListAllComponent implements OnInit {
  products
  faArrowAltCircleLeft=faArrowAltCircleLeft
faArrowAltCircleRight = faArrowAltCircleRight
  id: number
  currentPage:number

  constructor(private productService:ProductService,
    private route: ActivatedRoute,
    private router:Router,
    private cartService:CartService){

  }
  ngOnInit(): void {
    this.productService.getAllProducts(1).subscribe({
      next: (data: any) => {
        this.products = data;

      }
    });

    this.route.queryParams.subscribe(params => {
      this.currentPage = params.page
      if (this.currentPage == undefined) {
        this.productService.getAllProducts(1).subscribe({
          next: (data: any) => {
            this.products = data;
          }
        });
      }
      else {
        this.productService.getAllProducts(this.currentPage).subscribe({
          next: (data: any) => {
            this.products = data;
          }
        });
      }

    })
  }

  selectProduct(id: number) {
    this.router.navigate(['product', id]).then();
  }
  isButtonClicked = false;

  public disableButtonClick() {
    this.isButtonClicked = true;
  }

  AddToCart(id: number) {
    this.cartService.AddProductToCart(id);
  }
  onPrevious() {
    if (this.products.currentPage > 1) {
      this.products.currentPage--
      console.log(1);
      
      this.router.navigate(['products'], { queryParams: {page: this.products.currentPage } }).then()
    }
  }

  onAfter() {
    if (this.products.currentPage < this.products.pages) {
      this.products.currentPage++
      this.router.navigate(['products'], { queryParams: {page: this.products.currentPage } }).then();

    }
  }
}
