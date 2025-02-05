
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { appConfig } from './app.config';  // Import the new app config
import { AppComponent } from './app.component';  // Import your root component
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { GalleryModule } from 'ng-gallery';
import { FileUploadModule } from 'ng2-file-upload';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TimeagoModule } from 'ngx-timeago';
import { CoreModule } from './core/core.module';
import { HomeComponent } from './home/home.component';
import { RatingComponent } from './rating/rating.component';
import { FavouritesComponent } from './favourites/favourites.component';
import { LoadingInterceptor } from './core/interceptors/loading.interceptor';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,  // Declare your root component
    HomeComponent,
    RatingComponent,
    FavouritesComponent
  ],
  imports: [
    BrowserModule,  // Required for running Angular in the browser
    appConfig,  // Use the new appConfig for routing and change detection
    GalleryModule,
    HttpClient,
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    CoreModule,
    FormsModule,
    FileUploadModule,
    TimeagoModule.forRoot()
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]  // Bootstrap the root component
})
export class AppModule { }