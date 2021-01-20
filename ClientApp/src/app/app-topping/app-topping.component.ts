import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { Topping } from '../interfaces';
import { ToppingService } from '../topping.service';

@Component({
  selector: 'app-app-topping',
  templateUrl: './app-topping.component.html'
})
export class AppToppingComponent  {
  public toppings: Observable<Topping[]>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    protected toppingService: ToppingService,
    protected formBuilder: FormBuilder) {
    this.getToppings();
  }

  public getToppings() {
    this.toppings = this.toppingService.getToppings();
  }

  public delete(toppingId: number): void {
    this.toppingService.deleteTopping(toppingId);
  }
}

