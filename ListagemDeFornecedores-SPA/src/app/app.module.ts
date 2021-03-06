import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { EmpresasComponent } from './empresas/empresas.component';

@NgModule({
   declarations: [
      AppComponent,
      EmpresasComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,

   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
