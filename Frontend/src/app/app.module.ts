import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { HomeComponent } from './components/home/home.component';
import { ProductComponent } from './components/product/product.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HttpClientModule } from '@angular/common/http';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { GoogleLoginProvider,SocialLoginModule, SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { DoneComponent } from './components/done/done.component';
import { ListComponent } from './components/list/list.component';
import { SearchComponent } from './components/search/search.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AddProductComponent } from './components/dashboard/add-product/add-product.component';
import { ListOrderComponent } from './components/dashboard/list-order/list-order.component';
import { DetailProductComponent } from './components/dashboard/detail-product/detail-product.component';
import { ListUserComponent } from './components/dashboard/list-user/list-user.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { RegisterComponent } from './components/register/register.component';
import { ListAllComponent } from './components/list-all/list-all.component';
import { UpdateProductComponent } from './components/dashboard/update-product/update-product.component';
import {MatDialogModule} from '@angular/material/dialog';
import { PopUpComponent } from './components/pop-up/pop-up.component'

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    CartComponent,
    CheckoutComponent,
    HomeComponent,
    ProductComponent,
    LoginComponent,
    ProfileComponent,
    DoneComponent,
    ListComponent,
    SearchComponent,
    DashboardComponent,
    AddProductComponent,
    ListOrderComponent,
    DetailProductComponent,
    ListUserComponent,
    RegisterComponent,
    ListAllComponent,
    UpdateProductComponent,
    PopUpComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    HttpClientModule,
    NgxSpinnerModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    SocialLoginModule,
    FormsModule,
    ReactiveFormsModule,
    SlickCarouselModule,
    MatDialogModule

  ],
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '661974278308-nol9pp9pncfsa1on58s10jfbpi0joh4o.apps.googleusercontent.com'
            )
          }
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig,
    }
  ],
   bootstrap: [AppComponent]
})
export class AppModule { }
