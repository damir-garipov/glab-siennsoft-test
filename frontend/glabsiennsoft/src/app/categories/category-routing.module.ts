import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryComponent } from './category.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryAddComponent } from './category-add/category-add.component';

const routes: Routes = [
    {
        path: "categories",
        component: CategoryComponent,
        children: [
            {
                path: '',
                component: CategoryListComponent
            },
            {
                path: 'add',
                component: CategoryAddComponent
            }
        ]
    }
]

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class CategoryRoutingModule{

}