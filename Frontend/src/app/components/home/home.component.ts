import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';
import { CategoryModelServer } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  products;
  categories: CategoryModelServer[] = []
  // dependence injection
  constructor(private productService: ProductService,
    private categoryService: CategoryService,
    private cartService: CartService,
    private router: Router) {
    // this.getData();
  }

  ngOnInit(): void {
    this.productService.getAllProducts(1).subscribe({
      next: (data: any) => {
        this.products = data;
        console.log(data);
        

      }
    });

    this.categoryService.getAllCategories().subscribe({
      next: (data: any) => {
        this.categories = data;

      }
    });
  }
  selectCategory(id: number) {
    this.router.navigate(['list', id]).then();


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
}

