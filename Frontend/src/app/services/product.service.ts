import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { ProductModelServer,ServerResponse,FilterRequestByIdCategory } from '../models/product.model';
import { enviroment } from 'src/enviroments/enviroment';


//dependence injection
@Injectable({
  providedIn: 'root' //cung cap truic tiep vao trong root
})
export class ProductService {

  private SERVER_URL = enviroment.SERVER_URL;
  //Dua vao 2 service vao http client
  constructor(private http: HttpClient) {}

  filterObj = {
    "Name" : "",
    "PageNumber" : 1,
    "PageSize" : 10
  }

  productService(){
    return [
      {
        id: 1,
        name: "Dưới 1 triệu"
      },
      {
        id: 2,
        name: "Từ 1 đến 5 triệu"
      },
      {
        id: 3,
        name: "Từ 5 đến 10 triệu"
      },
      {
        id: 4,
        name: "Trên 10 triệu"
      }
    ]
  }

  //Lay toan bo products tu backend server
  // getAllProducts(numberOfResults : number = 10){
  //   // return this.http.get<Config>(this.SERVER_URL + '/products' + numberOfResults); 
  //   // return this.http.get(url: this.SERVER_URL + '/products');
  //   return this.http.get( this.SERVER_URL + 'Products');
  // }

  getAllProducts(page:number) : Observable<ServerResponse>{
    return this.http.get<ServerResponse>(this.SERVER_URL + 'api/Products/get-all?page=' + page)
  }

  //Lay mot san pham tu server
  getSingleProduct(id: number):Observable<ProductModelServer>{
    return this.http.get<ProductModelServer>(this.SERVER_URL + 'api/Products/Products/' + id)

    // https://localhost:44386/api/Products/Products/2
  }

  //Lay mot san pham tu mot categoryli
  getProductsFromCategory(catName : string): Observable<ProductModelServer[]>{
    return this.http.get<ProductModelServer[]>(this.SERVER_URL + 'api/Products/category/' + catName)
  }

  //Lay san pham theo loai san pham
  getProductByCategory(id : number,orderBy:string,page:number){
    return  this.http.get(this.SERVER_URL + 'api/Products/productByCategoryId/' + id + '?orderBy=' + orderBy + '&page=' + page)
    

    // ?page=1
  }

  getProductByName1(){
    return this.http.get(this.SERVER_URL + 'api/Products/search-by-name')
  }

  getProductByName2(name:string,page:number){
    return this.http.get(this.SERVER_URL + 'api/Products/search-by-name/?nameProduct=' + name + '&page=' + page)
  }
  //Them moi 
  insertProduct(products: {title:string,categoryId:string,quanity:number,price:number,description:string,image:string,images:string}){
    return this.http.post(this.SERVER_URL + 'api/Products',products);
  }

  //Chinh sua
  updateProduct(products: {id:number,title:string,categoryId:string,quanity:number,price:number,description:string,image:string,images:string}){
    return this.http.put(this.SERVER_URL + 'api/Products',products);
  }

  //Xoa bo
  deleteProduct(id:number){
    return this.http.delete(this.SERVER_URL + 'api/Products/' + id)
  }
  getCommentById(id:number){
    return this.http.get<ProductModelServer>(this.SERVER_URL + 'api/Products/get-comment/' + id)
  }

  //
  insertComment(user: Array<any>): any{
    return this.http.post(this.SERVER_URL + 'api/Products/comment',{
      userId:user[0],
      productId :user[1],
      username :user[2],
      email :user[3],
      content :user[4],
      ratingCount:user[5],
      createdBy:user[6],
      modifiedBy:user[7]})
  }
  
}
