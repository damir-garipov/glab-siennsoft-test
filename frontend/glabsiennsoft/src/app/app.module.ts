import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { AppRoutingModule }        from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { AvailableProductsComponent } from './availableproducts/availableproducts.component';
import { FiltrationComponent } from './filtration/filtration.component';
import { MatModule } from './mat.module';

import { CategoryModule } from './categories/category.module';
// import { DialogsModule } from './dialogs/dialogs.module';

import { httpFactory } from './services/http-interceptor/http.factory';
import { CustomInterceptor } from './services/http-interceptor/http-client.interceptor';
import { ProductService } from './availableproducts/product.service';
import { ProductinfoComponent } from './availableproducts/productinfo.component';


@NgModule({
  declarations: [
    AppComponent,
    AvailableProductsComponent,
    FiltrationComponent,
    ProductinfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatModule,
    BrowserAnimationsModule,
    CategoryModule,
    // DialogsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CustomInterceptor,
      multi: true,
    },
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
