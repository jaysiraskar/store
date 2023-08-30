import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { IProduct } from 'src/app/models/product';
import { IPagination } from 'src/app/models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'Store';
  products: IProduct[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5081/api/products?pageSize=50').subscribe(
      (response: any) => {
        const paginationResponse = response as IPagination;
        this.products = paginationResponse.data;
      },
      (error) => {
        console.error('API Request Error:', error);
      }
    );
  }
}
