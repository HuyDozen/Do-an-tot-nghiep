import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { map } from 'rxjs';
import { CategoryService } from 'src/app/services/category.service';
import { ProductService } from 'src/app/services/product.service';
import {faEdit} from '@fortawesome/free-solid-svg-icons'
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {
  id: number
  product: any
  thumbimages
  category
  url
  urls = []

  faEdit=faEdit

  constructor(private route: ActivatedRoute,
    private router:Router,
    private toast:ToastrService,
    private categoryService: CategoryService,
    private productService: ProductService) {

  }
  ngOnInit(): void {

    this.categoryService.getAllCategories().subscribe(prod => {
      this.category = prod
      console.log(this.category);

    })

    this.route.paramMap
      .pipe(
        map((param: ParamMap) => {
          // @ts-ignore
          return param.params.id;
        })
      )
      .subscribe(prodId => {
        this.id = prodId;
        this.productService.getSingleProduct(this.id).subscribe(prod => {
          this.product = prod;
          console.log(prod);

          if (prod.images !== null) {
            this.thumbimages = prod.images.split(';;')

          }
        });
      });
  }

  onSelectFile(event: any) {
    if (event.target.files) {
      this.product.image = null;
      console.log( 1);
      

      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]);
      //Upload dc file text va anh 
      reader.onload = (event: any) => {
        this.url = event.target.result;
      }
    }
  }
  onSelectFiles(event: any) {
    if (event.target.files) {
      this.urls = []
      let numFiles = event.target.files.length;
      for (let i = 0; i < numFiles; i++) {
        var reader = new FileReader();
        reader.readAsDataURL(event.target.files[i]);
        //Upload dc file text va anh 
        reader.onload = (events: any) => {
          this.urls.push(events.target.result);
        }

      }
    }
  }

 updateProduct(products: {id:number, title: string, categoryId: string, quanity: number, price: number, description: string, image: string, images: any }) 
  {
    products.id = this.id
    products.image = this.url
    let textImages = this.urls.join(";;")

    products.images = textImages

    console.log(products);

    this.productService.updateProduct(products).subscribe(prod => {
      console.log(1);
        this.toast.success(`Thành công`, "Sản phẩm đã sửa thành công", {
          timeOut: 1500,
          progressBar: true,
          progressAnimation: 'increasing',
          positionClass: 'toast-bottom-right'
        })
        this.router.navigate(['dashboard/detailproduct']).then()
     
      

    })


  }

}
