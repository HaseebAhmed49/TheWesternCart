
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { appConfig } from './app.config';  // Import the new app config
import { AppComponent } from './app.component';  // Import your root component
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { GalleryModule } from 'ng-gallery';
import { FileUploadModule } from 'ng2-file-upload';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TimeagoModule } from 'ngx-timeago';

@NgModule({
  declarations: [
    AppComponent  // Declare your root component
  ],
  imports: [
    BrowserModule,  // Required for running Angular in the browser
    appConfig,  // Use the new appConfig for routing and change detection
    GalleryModule,
    HttpClient,
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    FormsModule,
    FileUploadModule,
    TimeagoModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]  // Bootstrap the root component
})
export class AppModule { }