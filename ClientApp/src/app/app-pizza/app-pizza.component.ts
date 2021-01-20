import { Component, Inject } from '@angular/core';
import { PizzaService } from '../pizza.service';
import { Pizza, Topping } from '../interfaces';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-app-pizza',
  templateUrl: './app-pizza.component.html'
})
export class AppPizzaComponent {
  public pizzas: Observable<Pizza[]>;  
  public toppings: Observable<Topping[]>;
  
  public toppingToPizzaForm = this.formBuilder.group ({
    name : '',
    size : ''
  });

  public newPizzaForm = this.formBuilder.group ({
    toppingId: '',
    toppingQuantity: ''
  });

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    protected pizzaService: PizzaService,
    protected formBuilder: FormBuilder)
  {
    this.getPizzas();    
  }

  public getPizzas() {    
    this.pizzas = this.pizzaService.getPizzas();
    let pizzaIds : number[] = []
    this.pizzas.subscribe(data => data.forEach((item) => {      
      pizzaIds.push(item.pizzaId);            
    }));
    // TODO improve this section in order to display toppings by Pizza
    return this.loadToppingsForPizza(1);
  }  

  public delete(pizzaId : number):void {
    this.pizzaService.deletePizza(pizzaId);   
  }

  public add():void {
    console.log('Adding');
    this.pizzaService.addPizza( this.newPizzaForm.value);
  }
  
  public addToppingToPizza(pizzaId : number) {    
    this.pizzaService.addToppingtoPizza(pizzaId, this.toppingToPizzaForm.value);
    this.newPizzaForm.reset();    
  }

  private loadToppingsForPizza(pizzaId : number) { 
    this.toppings = this.pizzaService.getToppingsForPizza(pizzaId);
  }  
  
}

