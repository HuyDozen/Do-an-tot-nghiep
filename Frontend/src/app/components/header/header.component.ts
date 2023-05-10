import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {faUser} from '@fortawesome/free-regular-svg-icons'
import {faBagShopping,faSearch, faClose} from '@fortawesome/free-solid-svg-icons'
import { CartModelServer } from 'src/app/models/cart.model';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  cartData: CartModelServer;
  cartTotal: number;
  authState:boolean;

  faUser = faUser;
  faShoppingCart =faBagShopping;
  faSearch =faSearch;
  faClose = faClose;  
  
  show = false;
  showCart = false;

  constructor(public cartService: CartService,
    private router: Router,
    private userService:UserService){}
  
  
  ngOnInit(): void{
    this.cartService.cartTotal$.subscribe({
      next: (total) =>{
        this.cartTotal = total;
      }
    });

    this.cartService.cartData$.subscribe({next:(data) => {
      this.cartData = data;
    }});

    this.userService.authState$.subscribe({
      next : (authState:boolean) =>{
        this.authState = authState;
      }
    });
  }

  showSearch(){
    this.show = !this.show;  
  }

  selectSearch(name: string){
    console.log(name);
    
    if(name == "")
    {
      this.router.navigate(['/search'])
    }
    else
    this.router.navigate(['/search'],{queryParams: {name:name }})
    
  }

  showCart1(){
    this.showCart = !this.showCart;  
  }

  // setInputFocus(): void {
  //   setTimeout(() => {
  //     document.getElementById('codeInput').focus();
  //   }, 500);
// }
}
