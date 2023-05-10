import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { faEdit, faTrash, faList, faSearch, faL } from '@fortawesome/free-solid-svg-icons'
import { CategoryService } from 'src/app/services/category.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { faArrowAltCircleLeft, faArrowAltCircleRight, faClose } from '@fortawesome/free-solid-svg-icons'
import { MatDialog } from '@angular/material/dialog'
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-detail-product',
  templateUrl: './detail-product.component.html',
  styleUrls: ['./detail-product.component.css']
})
export class DetailProductComponent implements OnInit {
  products
  categories
  currentPage: number
  showDialog = false
  idOfProductSelected;
  dataOfProductSelected
  showLoading = true

  faArrowAltCircleLeft = faArrowAltCircleLeft
  faArrowAltCircleRight = faArrowAltCircleRight
  faEdit = faEdit
  faTrash = faTrash
  faList = faList
  faSearch = faSearch
  faClose = faClose


  constructor(private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    private toast: ToastrService) {

  }

  ngOnInit(): void {
    this.productService.getAllProducts(1).subscribe({
      next: (data: any) => {
        this.products = data;
      }
    });

    this.categoryService.getAllCategories().subscribe({
      next: (data: any) => {
        this.categories = data;
      }
    });

    this.route.queryParams.subscribe(params => {
      this.currentPage = params.page
      if (this.currentPage == undefined) {
        this.productService.getAllProducts(1).subscribe({
          next: (data: any) => {
            this.products = data;
            this.showLoading = false
          }
        });
      }
      else {
        this.productService.getAllProducts(this.currentPage).subscribe({
          next: (data: any) => {
            this.products = data;
            console.log(1);
            this.showLoading = false
          }
        });
      }
      if (this.idOfProductSelected != null) {
        this.productService.getSingleProduct(this.idOfProductSelected).subscribe({
          next: (data => {
            this.dataOfProductSelected = data
            console.log(data);
            this.showLoading = false

          })
        })
      }
      else
        return

    })



  }
  updateProduct(id: number) {
    this.router.navigate(['dashboard/detailproduct', id]).then();
  }

  onPrevious() {
    if (this.products.currentPage > 1) {
      this.products.currentPage--
      console.log(1);

      this.router.navigate(['dashboard/detailproduct'], { queryParams: { page: this.products.currentPage } }).then()
    }
  }

  onAfter() {
    if (this.products.currentPage < this.products.pages) {
      this.products.currentPage++
      this.router.navigate(['dashboard/detailproduct'], { queryParams: { page: this.products.currentPage } }).then();
      console.log(1);

    }
  }
  openDialog(id: number) {
    this.showDialog = !this.showDialog;
    this.idOfProductSelected = id
    this.router.navigate(['dashboard/detailproduct'], { queryParams: { page: this.products.currentPage, productid: this.idOfProductSelected } }).then();

  }
  closeDialog() {
    this.showDialog = !this.showDialog;

  }
  deleteProduct(id: number) {
    this.productService.deleteProduct(id).subscribe({
      next: (data => {
        console.log(data);
        
      })
    })

    this.showDialog = false
        console.log(1);
        this.toast.success(`Thành công`, "Sản phẩm đã được xoá", {
          timeOut: 1500,
          progressBar: true,
          progressAnimation: 'increasing',
          positionClass: 'toast-bottom-right'
        })
        this.router.navigate(['dashboard/detailproduct']).then()

  }
}
