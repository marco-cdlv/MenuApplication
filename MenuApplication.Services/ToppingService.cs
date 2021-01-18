using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MenuApplication.Core;
using MenuApplication.Core.Models;
using MenuApplication.Core.Services;

namespace MenuApplication.Services
{
    public class ToppingService : IToppingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToppingService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Topping> AddTopping(Topping newTopping)
        {
            await _unitOfWork.Toppings.AddAsync(newTopping);
            await _unitOfWork.CommitAsync();
            return newTopping;
        }

        public async Task DeleteTopping(Topping topping)
        {
            _unitOfWork.Toppings.Remove(topping);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Topping> GetTopping(int id)
        {
            return await _unitOfWork.Toppings
                .GetWithPizzaByIdAsync(id);
        }

        public async Task<IEnumerable<Topping>> GetToppings()
        {
            return await _unitOfWork.Toppings.GetAllAsync();
        }
    }
}
