import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Entity } from '../contracts/entity';
import { EntityCollectionInfo } from '../contracts/entitycollectioninfo';

@Injectable()
export class CategoryService{
    constructor(
        private http: HttpClient
    ){}

    getAllCategories():Observable<Entity[]>{
        let result = this.http.get("category").map<any, Entity[]>(res => {
            return res;
        });
        return result;
    }

    getCategoryPage(pageNumber: number, pageSize: number): Observable<EntityCollectionInfo>{
        let result = this.http.get(`category/page?pagenumber=${pageNumber}&pagesize=${pageSize}`).map<any, EntityCollectionInfo>(res => {
            return res;
        });
        return result;
    }

    removeCategory(element: Entity): Observable<boolean>{
        let result = this.http.delete(`category/${element.code}`);
        return result.map<any, boolean>(res => res);
    }
}
