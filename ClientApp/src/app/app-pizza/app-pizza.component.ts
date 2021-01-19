import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-app-pizza',
  templateUrl: './app-pizza.component.html'
})
export class AppPizzaComponent {
  public pizzas: Pizza[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Pizza[]>(baseUrl + 'api/Pizza').subscribe(result => {      
      this.pizzas = result;
      console.log('TEST ' + this.pizzas[0].name);      
    }, error => console.error(error));
  }
  
}

interface Pizza {
  pizzaId : number
  name: string;  
}
