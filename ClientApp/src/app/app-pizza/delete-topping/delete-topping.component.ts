import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Topping } from 'src/app/interfaces';
import { PizzaService } from 'src/app/pizza.service';

@Component({
  selector: 'app-delete-topping',
  templateUrl: './delete-topping.component.html'
})
export class DeleteToppingComponent {
  pizzaId: number;
  pizzaName: number;
  toppingsByPizza: Observable<Topping[]>;

  constructor(private route: ActivatedRoute,
    private pizzaService : PizzaService) { 
    this.pizzaId = +this.route.snapshot.params['pizzaId'];
    this.pizzaName = this.route.snapshot.params['pizzaName'];    
    this.getToppingsByPizza(this.pizzaId);
  }

  public getToppingsByPizza(pizzaId : number) {
    this.toppingsByPizza = this.pizzaService.getToppingsForPizza(pizzaId);
  } 

  public deleteToppingFromPizza(toppingId : number) {    
    this.pizzaService.deleteToppingFromPizza(this.pizzaId, toppingId);
  }
}
