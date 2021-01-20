export interface Pizza {
    pizzaId : number
    name: string;  
}

export interface PizzaDetail {
    pizzaDetailId : number
    pizzaId : number
    toppingId : number
    toppingQuantity : number

}

export interface Topping {
    toppingId : number
    name : string
    quantity : number
}

export interface NewPizza{
    name : string
    size : string;
}

export interface ToppingToPizza{
    toppingId : number
    ToppingQuantity : number;
}

