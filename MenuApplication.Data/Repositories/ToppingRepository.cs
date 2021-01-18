using MenuApplication.Core.Models;
using MenuApplication.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Data.Repositories
{
    public class ToppingRepository : Repository<Topping>, IToppingRepository    
    {
        public ToppingRepository(MyMenuContext context)
           : base(context)
        { }        

        public async Task<Topping> GetWithPizzaByIdAsync(int id)
        {
            return await MyMenuContext.Topings
                .Include(pd => pd.ToppingId)
                .SingleOrDefaultAsync(pd => pd.ToppingId == id);
        }

        public async Task<IEnumerable<Topping>> GetAllWithPizzasByPizzaIdAsync(int pizzaId)
        {
            List<PizzaDetails> pizzaDetails = await MyMenuContext.PizzaDetails
                .Where(pd => pd.PizzaId == pizzaId)
                .ToListAsync();

            List<int> toppingIds = new List<int>();
            foreach (var item in pizzaDetails)
            {
                toppingIds.Add(item.ToppingId);
            }

            return await MyMenuContext.Topings
                .Where(item => toppingIds.Contains(item.ToppingId))                
                .ToListAsync();
        }

        private MyMenuContext MyMenuContext
        {
            get { return Context as MyMenuContext; }
        }
    }
}
    