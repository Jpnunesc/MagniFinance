import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LOCALE_ID, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import localePt from '@angular/common/locales/pt';
import { AppRoutingModule } from './app.routing';


import { AppComponent } from './app.component';


import { DEFAULT_CURRENCY_CODE } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './components/auth/auth.interceptor';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule, registerLocaleData } from '@angular/common';
import { LayoutModule } from './layouts/layout.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


registerLocaleData(localePt, 'pt');

@NgModule({
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule,
    NgbModule,
    ToastrModule.forRoot(),
    LayoutModule,
    ReactiveFormsModule,
    FormsModule,
  ],
    declarations: [AppComponent],
  providers: [
    { provide: DEFAULT_CURRENCY_CODE, useValue: 'BRL' },
    { provide: LOCALE_ID, useValue: 'pt' },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],

    bootstrap: [AppComponent]
})
export class AppModule { }
