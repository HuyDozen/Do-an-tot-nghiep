import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  category: any
  url
  urls = []
  urlFiles
  constructor(private categoryService: CategoryService,
    private productService: ProductService
  ) {

  }

  ngOnInit(): void {
    this.categoryService.getAllCategories().subscribe(prod => {
      this.category = prod
      console.log(this.category);

    })
  }

  onSelectFile(event: any) {
    if (event.target.files) {
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



  async insertProduct(products: { title: string, categoryId: string, quanity: number, price: number, description: string, image: string, images: any }) 
  {
    products.image = this.url
    let textImages = this.urls.join(" ")

    products.images = textImages

    console.log(products);

    this.productService.insertProduct(products).subscribe(prod => {
      console.log(prod);

    })


  }
}
