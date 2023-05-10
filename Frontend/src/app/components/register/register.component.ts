import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import {  ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user : any
  repeatPass: string = 'none'
  constructor(private userService: UserService,
    private toast:ToastrService,
    private router:Router) {

  }
  ngOnInit(): void {

  }
  registerForm = new FormGroup({
    fname: new FormControl("", [Validators.required,
    Validators.pattern("[a-zA-Z].*")]),
    email: new FormControl("", [Validators.required,
    Validators.email]),
    age: new FormControl("", [Validators.required]),
    gender: new FormControl("", [Validators.required]),
    password: new FormControl("", [Validators.required,
    Validators.pattern("[0-9a-zA-Z!@#$%^&*]{8,20}")]),
    repeatPassword: new FormControl("", [Validators.required]),
    phoneNumber: new FormControl("", [Validators.required,
    Validators.pattern("[0-9]{10}"),]),
    username: new FormControl("", [Validators.required,
    Validators.pattern("[a-zA-Z].*[0-9a-zA-Z!@#$%^&*]{6,20}")])
  });

  registerSubmited() {
    if (this.Password.value == this.RepeatPassword.value) {
      this.repeatPass = 'none'
      console.log(this.registerForm.value);

      this.userService.signUp([
      this.registerForm.value.username,
      this.registerForm.value.password,
      this.registerForm.value.email,
      this.registerForm.value.fname,
      this.registerForm.value.age,
      this.registerForm.value.phoneNumber,
      this.registerForm.value.gender
      ]).subscribe({
        next : (data) => {
          data = this.user
          console.log(data);

          this.toast.success("Thành công","Bạn đã đăng ký tài khoản thành công",{
            timeOut: 2000,
            progressBar:true,
            progressAnimation: 'increasing',
            positionClass: 'toast-top-full-width'
        })  

        this.router.navigateByUrl('/login');
          
        }
      })
    }
    else
      this.repeatPass = 'inline'

  }

  get FullName(): FormControl {
    return this.registerForm.get("fname") as FormControl;
  }

  get Email(): FormControl {
    return this.registerForm.get("email") as FormControl;
  }
  get Age(): FormControl {
    return this.registerForm.get("age") as FormControl
  }
  get PhoneNumber(): FormControl {
    return this.registerForm.get("phoneNumber") as FormControl;
  }
  get Gender(): FormControl {
    return this.registerForm.get("gender") as FormControl
  }
  get Password(): FormControl {
    return this.registerForm.get("password") as FormControl;
  }
  get RepeatPassword(): FormControl {
    return this.registerForm.get("repeatPassword") as FormControl;
  }
  get Username(): FormControl {
    return this.registerForm.get("username") as FormControl
  }


}
