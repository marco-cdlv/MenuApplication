using MenuApplication.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuApplication.Core.Repositories
{
    public interface IToppingRepository : IRepository<Topping>
    {       
        Task<Topping> GetWithPizzaByIdAsync(int id);
        Task<IEnumerable<Topping>> GetAllWithPizzasByPizzaIdAsync(int pizzaId);
    }
}