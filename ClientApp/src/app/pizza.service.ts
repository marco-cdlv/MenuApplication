import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NewPizza, Pizza, TopingToPizza, Topping } from './interfaces';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {  
  public pizzas: Pizza[];
  baseUrl : string;  

  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;    
  }

  public getPizzas(): Observable<Pizza[]> {    
    return this.http.get<Pizza[]>(this.baseUrl + 'api/Pizza');    
  }

  public getPizza(id : number): Observable<Pizza[]> {    
    return this.http.get<Pizza[]>(this.baseUrl + 'api/Pizza/' + id);    
  }

  public getToppingsForPizza(pizzaId : number): Observable<Topping[]> {     
    let endpoint =  this.baseUrl + 'api/Pizza/{pizzaId}/Toppings';
    endpoint = endpoint.replace('{pizzaId}', pizzaId.toString());    
    return this.http.get<Topping[]>(endpoint);   
  }

  public deletePizza(pizzaId: number) {    
    this.http.delete<Pizza>(this.baseUrl + 'api/Pizza/'+ pizzaId).subscribe(() => {
        console.log('The pizza was removed')
       });    
  }

  public addPizza(bodyRequest : JSON) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    this.http.post<NewPizza>(this.baseUrl + 'api/Pizza', bodyRequest, httpOptions);
  }

  public addToppingtoPizza(pizzaId : number, bodyRequest : JSON) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    this.http.post<TopingToPizza>(this.baseUrl + 'api/Pizza/' + pizzaId, bodyRequest, httpOptions);
  }
}
