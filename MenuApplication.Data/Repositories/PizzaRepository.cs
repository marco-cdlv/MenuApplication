using MenuApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MenuApplication.Core.Respositories;

namespace MenuApplication.Data.Repositories
{
    public class PizzaRepository : Repository<Pizza>, IPizzaRespository
    {
        public PizzaRepository(MyMenuContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Pizza>> GetAllWithToppings()
        {
            return await MyMenuContext.Pizzas
                .Include(a => a.PizzaDetails)
                .ToListAsync();
        }

        public async Task<Pizza> GetWithToppingsByIdAsync(int id)
        {
            return await MyMenuContext.Pizzas
               .Include(a => a.PizzaDetails)
               .SingleOrDefaultAsync(a => a.PizzaId == id);
        }

        private MyMenuContext MyMenuContext
        {
            get { return Context as MyMenuContext; }
        }
    }
}
