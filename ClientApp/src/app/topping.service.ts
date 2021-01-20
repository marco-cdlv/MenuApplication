import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NewTopping, Topping } from './interfaces';

@Injectable({
  providedIn: 'root'
})
export class ToppingService {
  public toppings: Topping[];
  baseUrl: string;

  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public getToppings(): Observable<Topping[]> {
    return this.http.get<Topping[]>(this.baseUrl + 'api/Topping');
  }

  public deleteTopping(toppingId: number) {
    this.http.delete<Topping>(this.baseUrl + 'api/Topping/' + toppingId).subscribe(() => {
      console.log('The topping was removed')
     });    
  }

  
  public addTopping(topping: NewTopping) {    
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    this.http.post<NewTopping>(this.baseUrl + 'api/Topping', topping, httpOptions)
    .subscribe( response => { console.log(response)});
  }

}
