import { Component, OnInit } from '@angular/core'
import { Input } from '@angular/core/src/metadata/directives';
import { Product, ProductInfo } from '../contracts/product-entity';
import { ProductService } from './product.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
    selector: 'product-info',
    templateUrl: './productinfo.component.html',
    inputs: ['product']
})
export class ProductinfoComponent implements OnInit{
    product: ProductInfo;
    constructor(
        private productService: ProductService,
        private route: ActivatedRoute,
        private router: Router,    
    ){}
    
    ngOnInit(): void {
        let code = this.route.snapshot.paramMap.get('code');
        this.productService.getProductInfo(code)
            .subscribe((product: ProductInfo) => {
                this.product = product
            });            
    }

}