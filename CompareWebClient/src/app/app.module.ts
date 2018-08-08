import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { AuthGuard } from './Guards/AuthGuard';
import { AlertService } from './Services/alert.service';
import { AuthenticationService } from './Services/authentication.service';
import { RegionService } from './Services/region.service';
import { JwtInterceptor } from './Helpers/JwtInterceptor';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/Login/login.component';
import { routing } from './app-routing.module';
import { AlertComponent } from './Components/Alert/alert.component';
import { HomeComponent } from './Components/home/home.component';
import { RegionsComponent } from './Components/regions/regions.component';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';
import { LoadingBarModule } from '@ngx-loading-bar/core';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AlertComponent,
    HomeComponent,
    RegionsComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    LoadingBarHttpClientModule,
    LoadingBarRouterModule,
    LoadingBarModule.forRoot(),
    LoadingBarHttpClientModule,
    HttpClientModule,
    routing
  ],
  providers: [
    AuthGuard,
    AlertService,
    AuthenticationService,
    RegionService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: JwtInterceptor,
        multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
