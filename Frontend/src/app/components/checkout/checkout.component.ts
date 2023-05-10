import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { CartModelServer } from 'src/app/models/cart.model';
import { CartService } from 'src/app/services/cart.service';
import { Router } from '@angular/router'
import { UserService } from 'src/app/services/user.service';
import { FormGroup, FormBuilder, AbstractControl, Validators } from '@angular/forms'
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  customForm: FormGroup
  formErrors = {
    'email': '',
    'phone': '',
  }

  validationMessages = {
    'email': {
      'required': 'Email không được để trống',
      'emailDomain': 'Email phải có định dạng là @gmail.com'
    },

    'phoneNumber': {
      'required': 'Số điện thoại không được để trống',
      'checkPhone': 'Số điện thoại phải có đúng 10 số'
    }

  }

  cartTotal: number;
  cartData: CartModelServer
  userId = 2;

  constructor(private cartService: CartService,
    private fb: FormBuilder,
    private spinner: NgxSpinnerService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.cartService.cartData$.subscribe(data => this.cartData = data);
    this.cartService.cartTotal$.subscribe(total => this.cartTotal = total);
    this.userService.userData$.subscribe({
      next: (data) => {
        // @ts-ignore
        this.userId = data.userId || data.id;
      }
    });

    this.customForm = this.fb.group({
      email: ['', [Validators.required, emailDomain]],
      phoneNumber: ['', [Validators.required, checkNumber]],
      receiver : '',
      subject : 'Thông báo đặt đơn hàng thành công',
      body : 'Cảm ơn và hẹn gặp lại quý khách'
    })

    this.customForm.valueChanges.subscribe((data) => {
      this.logValidationErrors(this.customForm)
    })

  }
  onCheckout() {
    if (this.cartTotal > 0) {
      this.spinner.show().then(p => {
        this.cartService.checkoutFromCart(2);

      });
    } else {
      return;
    }
  }
  logValidationErrors(group: FormGroup = this.customForm) {
    Object.keys(group.controls).forEach((key: string) => {
      const AbstractControl = group.get(key);
      if (AbstractControl instanceof FormGroup) {
        this.logValidationErrors(AbstractControl);
      }
      else {
        this.formErrors[key] = '';
        if (AbstractControl && !AbstractControl.valid && (AbstractControl.touched || AbstractControl.dirty)) {
          const messages = this.validationMessages[key];
          for (const errorKey in AbstractControl.errors) {
            this.formErrors[key] += messages[errorKey]
          }
        }
      }
    })
  }

  selectSearch(name: string){
   
    console.log(name);
    
  }

}

function emailDomain(control: AbstractControl): { [key: string]: any } | null {
  const email: string = control.value;
  const domain = email.substring(email.lastIndexOf('@') + 1)

  if (email === '' || domain.toLowerCase() === 'gmail.com') {
    return null;
  } else {
    return { 'emailDomain': true }
  }
}

function checkNumber(control: AbstractControl): { [key: string]: any } | null {
  const phoneNumber: string = control.value;
  console.log(phoneNumber);


  if (phoneNumber === '') {
    return null;
  } else {
    return { 'checkPhone': true }
  }
}