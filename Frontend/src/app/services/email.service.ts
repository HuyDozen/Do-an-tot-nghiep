import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable, throwError } from 'rxjs';
import { enviroment } from 'src/enviroments/enviroment';
import { ServerResponse } from '../models/product.model';

//dependence injection
@Injectable({
    providedIn: 'root' //cung cap truic tiep vao trong root
  })
  export class EmailService {
    
    
    private SERVER_URL = enviroment.SERVER_URL;
    //Dua vao 2 service vao http client
    constructor(private http: HttpClient) {}

    sendEmail(data:any)  {
      // return this.http.get<Config>(this.SERVER_URL + '/products' + numberOfResults); 
      // return this.http.get(url: this.SERVER_URL + '/products');
      return this.http.post(this.SERVER_URL + 'api/Email/send-mail',data)
    }
}