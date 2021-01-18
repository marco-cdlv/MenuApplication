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

        public async Task AddToppingToPizza(int pizzaId, int toppingId, int quantity)
        {
            //throw new NotImplementedException();
            PizzaDetails pizzaDetails = new PizzaDetails
            {
                PizzaId = pizzaId,
                ToppingId = toppingId,
                ToppingQuantity = quantity
            };

            Console.WriteLine("Topping quantity " + pizzaDetails.ToppingQuantity);

            await _unitOfWork.PizzaDetails.AddAsync(pizzaDetails);
            await _unitOfWork.CommitAsync();
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

        public async Task<IEnumerable<Topping>> GetToppingsForPizza(int pizzaId)
        {
            return await _unitOfWork.PizzaDetails.GetToppingsByPizzaId(pizzaId);
        }
    }
}
