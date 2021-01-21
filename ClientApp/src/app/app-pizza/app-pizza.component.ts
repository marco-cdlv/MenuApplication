import { Component, Inject } from '@angular/core';
import { PizzaService } from '../pizza.service';
import { Pizza, Topping } from '../interfaces';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-app-pizza',
  templateUrl: './app-pizza.component.html'
})
export class AppPizzaComponent {
  public pizzas: Observable<Pizza[]>;  
  public pizzasWithToppings: FormGroup[] = [];  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    protected pizzaService: PizzaService,
    protected formBuilder: FormBuilder,
    protected router : Router)
  {
    this.getPizzas();    
  }  

  getPizzas() {    
    this.pizzaService.getPizzas().subscribe(data => 
      data.forEach((pizza) => {
        let pizzaWithToppingsForm: FormGroup;
        let toppings : FormGroup[] = []; 
        toppings = this.getToppingGroupsByPizzaId(pizza.pizzaId);        
        pizzaWithToppingsForm = this.formBuilder.group ({
          Pizza : pizza,
          Toppings: []
        });
        pizzaWithToppingsForm.controls['Toppings'].setValue(toppings);           
      this.pizzasWithToppings.push(pizzaWithToppingsForm);
    }));      
  }  

  public delete(pizzaId : number):void {
    this.pizzaService.deletePizza(pizzaId);       
  }  
  
  public addToppingToPizza(pizzaId: number) {    
    this.router.navigate(['/app-pizza/add-topping', pizzaId]);    
  }

  private getToppingGroupsByPizzaId(pizzaId : number) : FormGroup[] {
    let toppingGroups : FormGroup[] = [];
    this.pizzaService.getToppingsForPizza(pizzaId).subscribe(data => data.forEach(topping => {
      let toppingGroup : FormGroup;
      toppingGroup = this.formBuilder.group ({
        ToppingName : topping.name,
        ToppingId : topping.toppingId,
        ToppingQuantity : topping.quantity
      });
      toppingGroups.push(toppingGroup);      
    }));    
    return toppingGroups;    
  }
}

