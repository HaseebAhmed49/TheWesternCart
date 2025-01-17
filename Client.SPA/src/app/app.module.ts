import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { HttpClient } from '@angular/common/http';
import { GalleryModule } from 'ng-gallery';
import { FileUploadModule } from 'ng2-file-upload';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TimeagoModule } from 'ngx-timeago';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    GalleryModule,
    HttpClient,
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    FormsModule,
    FileUploadModule,
    TimeagoModule.forRoot()
  ]
})
export class AppModule { }
