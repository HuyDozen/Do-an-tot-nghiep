import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { faArrowAltCircleLeft, faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons'
import {ListModelServerWithName } from 'src/app/models/list.model';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  currentPage:number
  name:string
  faArrowAltCircleLeft = faArrowAltCircleLeft
  faArrowAltCircleRight = faArrowAltCircleRight
  
  products : ListModelServerWithName

  constructor(private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
    private cartService: CartService) {
      
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.currentPage = params.page
      this.name = params.name;
      console.log(1);
      
      if(this.name == null)
      {       
        this.productService.getProductByName1().subscribe({
          next: (data:any) => {
            this.products = data;
            
            
          }
        })
      }
      else{
        if(this.currentPage == undefined)
        this.productService.getProductByName2(this.name,1).subscribe({
          next: (data:any) => {
            this.products = data;
   
          }
        })
        else
        this.productService.getProductByName2(this.name,this.currentPage).subscribe({
          next: (data:any) => {
            this.products = data;
            console.log(data);
          }
        })
      }      
    })
  }
  AddToCart(id: number){
    this.cartService.AddProductToCart(id);
  }

  selectProduct(id: number){
    this.router.navigate(['product',id]).then();
  }
  onPrevious(){
    if (this.products.currentPage > 1) {
      this.products.currentPage--
      this.router.navigate(['search'], { queryParams: {name:this.name, page: this.products.currentPage } }).then()
    }
  }
  onAfter(){
    if (this.products.currentPage < this.products.pages) {
      this.products.currentPage++
      this.router.navigate(['search'], { queryParams: {name:this.name, page: this.products.currentPage } }).then()
    }
  }
}
