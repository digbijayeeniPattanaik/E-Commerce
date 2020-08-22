import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseurl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(brandId?: number, typeId?: number, sortSelected?: string) {
    let params = new HttpParams();
    if (brandId)
    {
      params = params.append('brandId', brandId.toString());
    }
    if (typeId)
    {
      params = params.append('typeId', typeId.toString());
    }
    if (sortSelected)
    {
      params = params.append('sort', sortSelected);
    }

    return this.http.get<IPagination>(this.baseurl + 'products', {observe: 'response', params})
    .pipe(map(response => {
      return response.body;
    }));
  }

  getBrand(){
    return this.http.get<IBrand[]>(this.baseurl + 'products/brands');
  }

  getProductType(){
    return this.http.get<IType[]>(this.baseurl + 'products/types');
  }
}
