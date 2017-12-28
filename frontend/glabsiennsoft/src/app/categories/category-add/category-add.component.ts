import { Component } from '@angular/core';

@Component({
    templateUrl: "./category-add.component.html",
    styleUrls: ['./category-add.component.scss']
})
export class CategoryAddComponent{
    title = "Category add!"
    categoryDescription: string;

    saveCategory():void{
        console.log(`Save ${this.categoryDescription}`);
    }
}