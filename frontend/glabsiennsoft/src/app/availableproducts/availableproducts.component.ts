import { Component, OnInit, ViewChild } from '@angular/core';
import {MatTableDataSource, MatPaginator} from '@angular/material';
import {PageEvent} from '@angular/material';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {MatSnackBar} from '@angular/material';
import { Router } from '@angular/router';

import { ProductService } from './product.service';
import { Product, ProductCollectionInfo } from '../contracts/product-entity';
import { PromptDialog, EntityEditDialog } from '../dialogs/dialogs';

@Component({
    selector: 'available-products',
    templateUrl: './availableproducts.component.html',
    styleUrls: ['./availableproducts.component.css']
})
export class AvailableProductsComponent implements OnInit{
    selectedProduct: any;
    title = 'Available Components';
    dataCount: number;
    dataSource: MatTableDataSource<Product>;
    pageSize: number = 10;
    displayedColumns = ['code', 'description', 'isAvailable', 'deliveryDate', 'typeDescription', 'unitDescription', 'price', "actions"];
    pageEvent: PageEvent;

    constructor(
      private productService: ProductService,
      private dialog: MatDialog,
      private snackBar: MatSnackBar,
      private router: Router
    ){}

    @ViewChild(MatPaginator) paginator: MatPaginator;

    ngOnInit(): void {
      this.loadData(1, this.pageSize);
      this.paginator.ngOnInit();
    }

    reload(){
      let pageNumber = this.pageEvent ? this.pageEvent.pageIndex + 1 : 1;
      let pageSize =  this.pageEvent ? this.pageEvent.pageSize : this.pageSize;
      this.loadData(pageNumber, pageSize);
    }

    loadData(pageNumber: number, pageSize: number){
        this.productService.getAvailableProducts(pageNumber, pageSize).subscribe(res => {
            this.dataSource = new MatTableDataSource<Product>(res.entities);
            this.dataCount = res.count;
        });
    }

    deleteItem(element: Product){
        let dialogRef = this.dialog.open(PromptDialog, {
          width: '400px',
          data: {action: `Delete category ${element.description}`}
        });

      dialogRef.afterClosed().subscribe(result => {
          if (!result)
              return;
          
          this.productService.removeProduct(element).subscribe(res => {
              if (res)
                  this.reload();
          }, err => {
              this.snackBar.open(err.message, 'Error', {duration: 2000});
          });
      });
    }

    edit(row){

    }

    select(row){
      this.router.navigate(['/productinfo', row.code]);
    }

    changePage(event){
      this.pageEvent = event;
      this.loadData(event.pageIndex+1, event.pageSize);
    }
}