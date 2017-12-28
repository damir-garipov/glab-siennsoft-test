import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AvailableProductsComponent } from './availableproducts/availableproducts.component';
import { FiltrationComponent } from './filtration/filtration.component';
import { ProductinfoComponent } from './availableproducts/productinfo.component';

const appRoutes: Routes = [
    {
        path: "",
        redirectTo: "/available",
        pathMatch: 'full'
    },
    {
        path: "available",
        component: AvailableProductsComponent
    },
    {
        path: "productinfo/:code",
        component: ProductinfoComponent
    },
    {
        path: "filtration",
        component: FiltrationComponent
    }
  ];

@NgModule({
    imports: [
      RouterModule.forRoot(
        appRoutes,
        {
          enableTracing: true, // <-- debugging purposes only
        }
      )
    ],
    exports: [
      RouterModule
    ]
  })
  export class AppRoutingModule { }