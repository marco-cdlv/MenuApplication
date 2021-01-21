import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NewPizza } from 'src/app/interfaces';
import { PizzaService } from 'src/app/pizza.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html'
})
export class AddComponent {  

  newPizzaForm : FormGroup;
  newPizza : NewPizza;

  constructor(protected formBuilder : FormBuilder,     
    private pizzaService : PizzaService,
    private router : Router) { 
      this.newPizzaForm = formBuilder.group ({
        Name : '',
        Size : ''
      });
    }  

  public onSubmit() {    
    this.newPizza = this.newPizzaForm.value;
    this.pizzaService.addPizza(this.newPizza);
    this.router.navigate(['/app-pizza']);
  }
}
