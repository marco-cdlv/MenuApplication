using MenuApplication.Core;
using MenuApplication.Core.Models;
using MenuApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuApplication.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PizzaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Pizza> AddPizza(Pizza newPizza)
        {
            await _unitOfWork.Pizzas
               .AddAsync(newPizza);
            await _unitOfWork.CommitAsync();

            return newPizza;
        }

        public Task AddToppingToPizza(string pizzaId, Topping topping)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePizza(Pizza pizza)
        {
            _unitOfWork.Pizzas.Remove(pizza);

            await _unitOfWork.CommitAsync();
        }

        public async Task<Pizza> Getpizza(int id)
        {
            return await _unitOfWork.Pizzas.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _unitOfWork.Pizzas.GetAllAsync();
        }

        public Task GetToppingsForPizza(int pizzaId)
        {
            throw new NotImplementedException();
        }
    }
}
