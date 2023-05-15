import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';

// modules
import { AuthModule } from './auth/auth.module';
import { AdminModule } from './admin/admin.module';

// components
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AuthModule,
    AdminModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
