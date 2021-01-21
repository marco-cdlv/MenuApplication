import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, FormBuilder, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AppPizzaComponent } from './app-pizza/app-pizza.component';
import { AppToppingComponent } from './app-topping/app-topping.component';

import { PizzaService } from './pizza.service';
import { AddComponent } from './app-pizza/add/add.component';
import { AddToppingComponent } from './app-pizza/add-topping/add-topping.component';
import { AddNewToppingComponent } from './app-topping/add-new-topping/add-new-topping.component';
import { ToppingService } from './topping.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,   
    AppPizzaComponent,
    AppToppingComponent,
    AddComponent,
    AddToppingComponent,
    AddNewToppingComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },      
      { path: 'app-pizza', component: AppPizzaComponent },
      { path: 'app-pizza/add', component: AddComponent },
      { path: 'app-pizza/add-topping/:pizzaId', component: AddToppingComponent },
      { path: 'app-topping', component: AppToppingComponent },
      { path: 'app-topping/add-new-topping', component: AddNewToppingComponent }
    ])
  ],
  providers: [PizzaService, ToppingService, FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
