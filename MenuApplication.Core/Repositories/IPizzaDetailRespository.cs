using MenuApplication.Core.Models;
using MenuApplication.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuApplication.Core.Respositories
{
    public interface IPizzaDetailRespository : IRepository<PizzaDetails>
    {
        Task<IEnumerable<Topping>> GetToppingsByPizzaId(int pizzaId);
    }
}
