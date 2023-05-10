import { AfterViewInit, Component, OnInit, ViewChild ,OnChanges, Input} from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { faStar, faHeart } from '@fortawesome/free-regular-svg-icons'
import { faPlus, faCodeCompare } from '@fortawesome/free-solid-svg-icons'
import { faFacebook, faTwitter, faGoogle, faDiscord } from '@fortawesome/free-brands-svg-icons'
import {faClose} from '@fortawesome/free-solid-svg-icons'
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';

declare let $: any;

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit, AfterViewInit, OnChanges{

  @Input() property: string = 'default';

  faStar = faStar;
  faHeart = faHeart;
  faPlus = faPlus;
  faCodeCompare = faCodeCompare;
  faFacebook = faFacebook
  faTwitter = faTwitter
  faGoogle = faGoogle
  faDiscord = faDiscord
  faClose = faClose

  id: number;
  product;
  thumbimages: any[] = [];
  comments
  countOfComment:number
  showDialog:boolean = false
  user
  userName
  @ViewChild('quantity') quantityInput;

  constructor(private productService: ProductService,
    private toast:ToastrService,
    private cartService: CartService,
    private route: ActivatedRoute,
    private router:Router) {
      
  }
  
  ngOnChanges(changes){
    console.log('Changed', changes.property.currentValue, changes.property.previousValue);
  }
  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem("user"));
  
    console.log('Init', this.property);
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
          
          
          if (prod.images !== null) {
            this.thumbimages = prod.images.split(';;');
            
            
          }
        });
        this.productService.getCommentById(this.id).subscribe(prod => {
       
          this.comments = prod;
          this.countOfComment = this.comments.count
        })
      });

      this.getProductByCateId();
  }
  reviewForm = new FormGroup({
    vote: new FormControl(""),
    name : new FormControl(""),
    email:new FormControl(""),
    content:new FormControl("")
  })
  reviewSubmited(){
    console.log(this.reviewForm.value);
    // this.productService.insertComment([
    //   2,
    //   this.id,
    //   this.reviewForm.value.name,
    //   this.reviewForm.value.email,
    //   this.reviewForm.value.content,
    //   this.reviewForm.value.vote,
    //   this.reviewForm.value.name,
    //   this.reviewForm.value.name
    // ]).subscribe(data => {
    //   console.log(data);
    //   this.toast.success(`Thành công`, "Bạn đã bình luận về sản phẩm", {
    //     timeOut: 1500,
    //     progressBar: true,
    //     progressAnimation: 'increasing',
    //     positionClass: 'toast-bottom-right'
    //   })
    //   this.showDialog = false
    //     window.location.reload();
    // })
  }
  getProductByCateId(){
    
  }

  ngAfterViewInit(): void {

//     // Product Main img Slick
// $('#product-main-img').slick({
//       infinite: true,
//       speed: 300,
//       dots: false,
//       arrows: true,
//       fade: true,
//       asNavFor: '#product-imgs',
//     });

//     // Product imgs Slick
//     $('#product-imgs').slick({
//       slidesToShow: 3,
//       slidesToScroll: 1,
//       arrows: true,
//       centerMode: true,
//       focusOnSelect: true,
//       centerPadding: 0,
//       vertical: true,
//       asNavFor: '#product-main-img',
//       responsive: [{
//         breakpoint: 991,
//         settings: {
//           vertical: false,
//           arrows: false,
//           dots: true,
//         }
//       },
//       ]
//     });

    // Product img zoom
    var zoomMainProduct = document.getElementById('product-main-img');
    if (zoomMainProduct) {
      $('#product-main-img .product-preview').zoom();
    }
  }

  Increase() {
    let value = parseInt(this.quantityInput.nativeElement.value);

    if (this.product.quantity >= 1) {
      value++;

      if (value > this.product.quantity) {
        value = this.product.quantity;
      }
    } else {
      return;
    }

    this.quantityInput.nativeElement.value = value.toString();

  }

  Decrease() {
    let value = parseInt(this.quantityInput.nativeElement.value);

    if (this.product.quantity > 0) {
      value--;

      if (value <= 1) {
        value = 1;
      }
    } else {
      return;
    }

    this.quantityInput.nativeElement.value = value.toString();
  }

  addToCart(id: number) {
    this.cartService.AddProductToCart(id, this.quantityInput.nativeElement.value);
  }

  selectCategory(id : number){
    this.router.navigate(['list',id]).then()
   
    
    
  }
  closeDialog() {
    this.showDialog = !this.showDialog;

  }
  openDialog() {
    this.showDialog = !this.showDialog;

  }
}

