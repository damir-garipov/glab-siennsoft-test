import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoryService } from '../category-service';
import {MatTableDataSource, MatPaginator} from '@angular/material';
import {PageEvent} from '@angular/material';
import { Entity } from '../../contracts/entity';
import { EntityCollectionInfo } from '../../contracts/entitycollectioninfo';
import { EntityEditDialog, PromptDialog } from '../../dialogs/dialogs';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {MatSnackBar} from '@angular/material';


import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Component({
    templateUrl: "./category-list.component.html",
    styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit{
    dataCount: number;
    dataSource: MatTableDataSource<Entity>;
    pageSize: number = 10;
    title = "Category List!"
    displayedColumns = ['code', 'description', "actions"];
    pageEvent: PageEvent;

    constructor(
        private categoryService: CategoryService,
        private dialog: MatDialog,
        private snackBar: MatSnackBar
    ){

    }

    @ViewChild(MatPaginator) paginator: MatPaginator;

    ngOnInit(): void {
        this.loadData(1, this.pageSize);
        this.paginator.ngOnInit();
    }
 
    changePage(event:PageEvent){
        this.pageEvent = event;
        this.loadData(event.pageIndex+1, event.pageSize);
    }

    reload(){
        let pageNumber = this.pageEvent ? this.pageEvent.pageIndex + 1 : 1;
        let pageSize =  this.pageEvent ? this.pageEvent.pageSize : this.pageSize;
        this.loadData(pageNumber, pageSize);
    }

    loadData(pageNumber: number, pageSize: number){
        this.categoryService.getCategoryPage(pageNumber, pageSize).subscribe(res => {
            this.dataSource = new MatTableDataSource<Entity>(res.entities);
            this.dataCount = res.count;
        });
    }

    deleteItem(element: Entity){
        let dialogRef = this.dialog.open(PromptDialog, {
            width: '400px',
            data: {action: `Delete category ${element.description}`}
        });

        dialogRef.afterClosed().subscribe(result => {
            if (!result)
                return;
            
            this.categoryService.removeCategory(element).subscribe(res => {
                if (res)
                    this.reload();
            }, err => {
                this.snackBar.open(err.message, 'Error', {duration: 2000});
            });
        });
    }

    edit(element){
        console.log(element);
    }
}
