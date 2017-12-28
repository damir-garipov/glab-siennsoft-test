import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import {Product, ProductCollectionInfo, ProductInfo} from '../contracts/product-entity';

@Injectable()
export class ProductService{
    constructor(private http: HttpClient){

    }

    getAvailableProducts(pageNumber: number, pageSize: number): Observable<ProductCollectionInfo>{
        return this.http.get(`product/available?pageNumber=${pageNumber}&pageSize=${pageSize}`).map<any, ProductCollectionInfo>(res => {
            return res;
        });
    };

    removeProduct(item: Product): any {
        let result = this.http.delete(`product/${item.code}`);
        return result.map<any, boolean>(res => res);
    }

    getProductInfo(code): Observable<ProductInfo> {
        return this.http.get(`product/${code}/info`).map<any, ProductInfo>(res => {
            return res;
        });
    }
}