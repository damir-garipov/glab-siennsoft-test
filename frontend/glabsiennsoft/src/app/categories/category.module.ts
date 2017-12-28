import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MatModule } from '../mat.module';
import { CategoryComponent } from './category.component';
import { CategoryRoutingModule } from './category-routing.module';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryAddComponent } from './category-add/category-add.component';
import { CategoryService } from './category-service';
import { DialogsModule } from '../dialogs/dialogs.module';

@NgModule({
    declarations: [
        CategoryComponent,
        CategoryListComponent,
        CategoryAddComponent,
    ],
    imports: [
        BrowserModule,
        FormsModule,
        MatModule,
        CategoryRoutingModule,
        DialogsModule
    ],
    providers: [
        CategoryService
    ]
})
export class CategoryModule{

}