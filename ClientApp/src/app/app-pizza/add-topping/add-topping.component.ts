import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Topping, ToppingToPizza } from 'src/app/interfaces';
import { PizzaService } from 'src/app/pizza.service';
import { ToppingService } from 'src/app/topping.service';

@Component({
  selector: 'app-add-topping',
  templateUrl: './add-topping.component.html'
})
export class AddToppingComponent {
  toppings : Observable<Topping[]>;
  toppingToPizza : ToppingToPizza; 
  pizzaId : number;
  newToppingPizzaForm :FormGroup;  

  constructor(private route: ActivatedRoute, 
    protected toppingService: ToppingService,
    protected pizzaService: PizzaService,
    protected formBuilder : FormBuilder,
    protected router : Router) {    
    this.pizzaId = +this.route.snapshot.params['pizzaId'];     

    this.newToppingPizzaForm = formBuilder.group ({
      ToppingId : '',
      ToppingQuantity : ''
    });

    this.getToppings();
  }
  
  public getToppings() {
    this.toppings = this.toppingService.getToppings();
  }

  public onSubmit() {
    this.newToppingPizzaForm.controls['ToppingId'].setValue(Number(this.newToppingPizzaForm.controls['ToppingId'].value));
    this.newToppingPizzaForm.controls['ToppingQuantity'].setValue(Number(this.newToppingPizzaForm.controls['ToppingQuantity'].value));
    this.toppingToPizza = this.newToppingPizzaForm.value;
    this.pizzaService.addToppingtoPizza(this.pizzaId, this.toppingToPizza);
    this.router.navigate(['/app-pizza']);
  }
}
