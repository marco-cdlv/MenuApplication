using MenuApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Core.Services
{
    public interface IPizzaService
    {
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> Getpizza(int id);
        Task<Pizza> AddPizza(Pizza newPizza);        
        Task DeletePizza(Pizza pizza);
        Task AddToppingToPizza(int pizzaId, int toppingId, int quantity);
        Task<IEnumerable<Topping>> GetToppingsForPizza(int pizzaId);
    }
}
