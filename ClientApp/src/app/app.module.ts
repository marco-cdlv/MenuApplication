import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, FormBuilder } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AppPizzaComponent } from './app-pizza/app-pizza.component';
import { AppToppingComponent } from './app-topping/app-topping.component';

import { PizzaService } from './pizza.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,   
    AppPizzaComponent,
    AppToppingComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },      
      { path: 'app-pizza', component: AppPizzaComponent },
      { path: 'app-topping', component: AppToppingComponent }
    ])
  ],
  providers: [PizzaService, FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
