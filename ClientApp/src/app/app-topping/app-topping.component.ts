import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-app-topping',
  templateUrl: './app-topping.component.html'
})
export class AppToppingComponent  {
  public toppings: Topping[]

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Topping[]>(baseUrl + 'api/Topping').subscribe(result => {      
      this.toppings = result;
      console.log('TEST ' + this.toppings[0].name);      
    }, error => console.error(error));
  }

  public delete(toppingId : number):void {
    console.log(toppingId + ' topping id to delete' );
  }
}

interface Topping {
  toppingId : number
  name: string;  
  quantity: number; 
}