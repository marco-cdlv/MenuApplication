using MenuApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Core.Services
{
    interface IToppingService
    {
        Task<IEnumerable<Topping>> GetToppings();
        Task<Topping> GetTopping(int id);
        Task<Topping> AddTopping(Topping newTopping);
        Task DeleteTopping(Topping topping);
    }
}
