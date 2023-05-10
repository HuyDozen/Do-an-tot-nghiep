import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { HomeComponent } from './components/home/home.component';
import { ProductComponent } from './components/product/product.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ProfileGuard } from './guard/profile.guard';
import { DoneComponent } from './components/done/done.component';
import { ListComponent } from './components/list/list.component';
import { SearchComponent } from './components/search/search.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AddProductComponent } from './components/dashboard/add-product/add-product.component';
import { ListOrderComponent } from './components/dashboard/list-order/list-order.component';
import { ListUserComponent } from './components/dashboard/list-user/list-user.component';
import { DetailProductComponent } from './components/dashboard/detail-product/detail-product.component';
import { RegisterComponent } from './components/register/register.component';
import { DashboardGuard } from './guard/dashboard.guard';
import { ListAllComponent } from './components/list-all/list-all.component';
import { UpdateProductComponent } from './components/dashboard/update-product/update-product.component';

const routes: Routes = [
  {
    //Mot dg dan mac dinh va tro den homecomponent
    path: '', component: HomeComponent
  },
  {
    path: 'product/:id', component: ProductComponent
  },
  {
    path: 'cart', component: CartComponent
  },
  {
    path: 'checkout', component:CheckoutComponent
  },
  {
    path: 'done' ,component: DoneComponent
  },
  {
    path: 'login' ,component: LoginComponent
  },
  {
    path: 'register',component: RegisterComponent
  },
  {
    path: 'list/:id' , component: ListComponent
  },
  {
    path: 'search',component:SearchComponent
  },
  {
    path: 'profile',component: ProfileComponent,canActivate:[ProfileGuard]
  },
  {
    path: 'products',component:ListAllComponent
  },
  {
    path: 'dashboard',component:DashboardComponent, canActivate:[DashboardGuard],
    children : [
    {
      path: 'addproduct',component:AddProductComponent
    },
    {
      path: 'listorder',component:ListOrderComponent
    },
    {
      path: 'listuser',component:ListUserComponent
    },
    {
      path: 'detailproduct',component:DetailProductComponent
    },
    {
      path : 'detailproduct/:id',component:UpdateProductComponent
    }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
