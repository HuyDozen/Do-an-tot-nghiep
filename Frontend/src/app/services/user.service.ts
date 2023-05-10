import { Injectable } from '@angular/core';
import { GoogleLoginProvider, SocialAuthService, SocialUser } from "@abacritt/angularx-social-login";
import { enviroment } from 'src/enviroments/enviroment';
import { BehaviorSubject, catchError, of } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  auth: boolean = false;
  private SERVER_URL = enviroment.SERVER_URL;

  private user;

  authState$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(this.auth)
  userData$: BehaviorSubject<SocialUser | ResponseModel> = new BehaviorSubject<SocialUser | ResponseModel>(null)
  loginMessage$ = new BehaviorSubject<string>(null);
  userRole: string;
  token:string
  role:string

  constructor(private socialAuthService: SocialAuthService,
    private toast:ToastrService,
    private httpClient: HttpClient) {


    socialAuthService.authState.subscribe({
      next: (user: SocialUser) => {
        if (user !== null) {
          this.auth = true;
          this.authState$.next(this.auth);
          this.userData$.next(user);
        }
      }
    });
  }
  //Login user with email vs password
  loginUser(userName: string, password: string) {
    this.httpClient.post<ResponseModel>(`${this.SERVER_URL}api/Users/login-user`, { userName, password })
      .pipe(catchError((err: HttpErrorResponse) => of(err.error.message)))
      .subscribe({
        next: (data: ResponseModel) => {
          if (data == undefined) {
            //display a TOAST NOTIFICATION  
            console.log(1);
            
            this.toast.warning("Có lỗi","Thông tin đăng nhập không chính xác",{
              timeOut: 1500,
              progressBar:true,
              progressAnimation: 'increasing',
              positionClass: 'toast-top-full-width'
          })  
          } else {
            //display a TOAST NOTIFICATION  
           
            this.toast.success("Thành công","Thông tin đăng nhập thành công",{
              timeOut: 1500,
              progressBar:true,
              progressAnimation: 'increasing',
              positionClass: 'toast-top-full-width'
          })  
            
            this.auth = data.auth;
            this.role = data.role;
            console.log(this.role);
            
            this.token = data.tokenModel.accessToken;
            this.setToken(this.token)
            
            this.authState$.next(this.auth);
            this.userData$.next(data);
            this.setInforUser(JSON.stringify(this.userData$.getValue()))
            
          }
        }
      })
  }

  setToken(token:string){
    localStorage.setItem("access_token",token)
  }

  setInforUser (user){
    localStorage.setItem("user",user); 
  }
  //Google Authentication
  googleLogin(): void {
    this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);

  }
  logout() {
    this.socialAuthService.signOut();
    this.auth = false;
    this.authState$.next(this.auth);
    return localStorage.setItem("user",null)
  }
  getAllUsers() : any{
    // return this.http.get<Config>(this.SERVER_URL + '/products' + numberOfResults); 
    // return this.http.get(url: this.SERVER_URL + '/products');
    return this.httpClient.get(this.SERVER_URL + 'api/Users')
  }

  signUp(user: Array<string>): any{
    return this.httpClient.post(this.SERVER_URL + 'api/Users/sign-up',{
      Username:user[0],
      Password :user[1],
      Email :user[2],
      FullName :user[3],
      Age :user[4],
      PhoneNumber:user[5],
      Gender:user[6]
    })
  }
}

export interface ResponseModel {
  role:string
  age:number,
  auth:boolean,
  emai:string,
  message:string,
  tokenModel : 
    {
      accessToken:string,
      refreshToken:string,
    }
  
  userId :number
  userName:string
}
