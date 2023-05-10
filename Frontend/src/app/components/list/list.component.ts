import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { faTag, faClose } from '@fortawesome/free-solid-svg-icons'
import { CartService } from 'src/app/services/cart.service';
import { FilterRequestByIdCategory } from 'src/app/models/product.model';
import { map } from 'rxjs';
import { faArrowAltCircleLeft, faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons'


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  faArrowAltCircleLeft = faArrowAltCircleLeft
  faArrowAltCircleRight = faArrowAltCircleRight
  faTag = faTag
  faClose = faClose
  filterObj: FilterRequestByIdCategory
  products;


  id: number
  currentPage: number
  orderBy:string | null

  checkboxArray: any = [
    {
      id: 1,
      type: "checkbox",
      name: "Dưới 1 triệu"
    },
    {
      id: 2,
      type: "checkbox",
      name: "Từ 1 đến 5 triệu"
    },
    {
      id: 3,
      type: "checkbox",
      name: "Từ 5 đến 10 triệu"
    },
    {
      id: 4,
      type: "checkbox",
      name: "Trên 10 triệu"
    }
  ]

  constructor(private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
    private cartService: CartService) {
  }

  ngOnInit(): void {
    this.getProduct()
    this.productArray = []



    this.route.paramMap
      .pipe(
        map((param: ParamMap) => {
          // @ts-ignore
          return param.params.id;
        })

      )
      .subscribe(prodId => {
        this.id = prodId
        this.route.queryParams.subscribe(params => {
          this.orderBy = params.orderBy
          this.currentPage = params.page
          if (this.currentPage == undefined) {
            this.productService.getProductByCategory(this.id,this.orderBy, 1).subscribe({
              next: (data: any) => {
                this.products = data;
              }
            });
          }
          else {
            this.productService.getProductByCategory(this.id,this.orderBy,this.currentPage).subscribe({
              next: (data: any) => {
                this.products = data;
              }
            });
          }

        })
      });

  }



  productArray: any = []
  arrays: any = []
  getProduct() {
    this.productArray = this.productService.productService();
    this.arrays = this.productService.productService();
  }

  tempArray: any = []
  newArray: any = []
  onChange(event: any) {
    if (event.target.checked) {
      this.tempArray = this.arrays.filter(
        (e: any) => e.id == event.target.value)
      this.productArray = []
      this.newArray.push(this.tempArray)
      for (let i = 0; i < this.newArray.length; i++) {
        var firstArray = this.newArray[i]
        for (let i = 0; i < firstArray.length; i++) {
          var obj = firstArray[i]
          this.productArray.push(obj)
        }
      }
    }
    else {
      this.tempArray = this.productArray.filter((e: any) => e.id != event.target.value);
      this.newArray = []
      this.productArray = []
      this.newArray.push(this.tempArray)
      for (let i = 0; i < this.newArray.length; i++) {
        var firstArray = this.newArray[i]
        for (let i = 0; i < firstArray.length; i++) {
          var obj = firstArray[i]
          this.productArray.push(obj)
        }
      }

    }

  }

  

  AddToCart(id: number) {
    this.cartService.AddProductToCart(id);

  }

  selectProduct(id: number) {
    this.router.navigate(['product', id]).then();
  }


  onPrevious() {
    if (this.products.currentPage > 1) {
      this.products.currentPage--
     
      
      this.router.navigate(['list', this.id], { queryParams: { orderBy: this.orderBy, page: this.products.currentPage } }).then()
    }
  }

  onAfter() {
    if (this.products.currentPage < this.products.pages) {
      this.products.currentPage++
      this.router.navigate(['list', this.id], { queryParams: { orderBy: this.orderBy,page: this.products.currentPage } }).then();

    }
  }

  sortByNameAsc(){
    this.orderBy = 'name_asc'
    this.router.navigate(['list', this.id], { queryParams: {orderBy: this.orderBy ,page: this.products.currentPage } }).then();
    console.log(1);
    
  }
  sortByNameDesc(){
    this.orderBy = 'name_desc'
    this.router.navigate(['list', this.id], { queryParams: {orderBy:  this.orderBy ,page: this.products.currentPage } }).then();
  }
  sortByPriceAsc(){
    this.orderBy = 'price_asc'
    this.router.navigate(['list', this.id], { queryParams: {orderBy: this.orderBy ,page: this.products.currentPage } }).then();
  }
  sortByPriceDesc(){
    this.orderBy = 'price_desc'
    this.router.navigate(['list', this.id], { queryParams: {orderBy: this.orderBy ,page: this.products.currentPage } }).then();
  }
}
