using MenuApplication.Core.Models;
using MenuApplication.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuApplication.Core.Respositories
{
    public interface IPizzaRespository : IRepository<Pizza>
    {
        Task<IEnumerable<Pizza>> GetAllWithToppings();
        Task<Pizza> GetWithToppingsByIdAsync(int id);        
    }
}
