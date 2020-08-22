import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {IProduct} from './models/product';
import {IPagination} from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: IProduct[];
  constructor(private http: HttpClient){
    this.http.get('https://localhost:5001/api/products?pageSize=50').subscribe((response: IPagination) => {
      this.products = response.data;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  ngOnInit(): void {

  }
}
