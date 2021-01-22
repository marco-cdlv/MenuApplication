using MenuApplication.Core.Models;
using MenuApplication.Core.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Data.Repositories
{
    public class PizzaDetailRepository : Repository<PizzaDetails>, IPizzaDetailRespository
    {
        public PizzaDetailRepository(MyMenuContext context) : base(context)
        { }        

        public async Task<IEnumerable<Topping>> GetToppingsByPizzaId(int pizzaId)
        {
            IEnumerable<PizzaDetails> pizzaDetailByPizzaId = MyMenuContext.PizzaDetails
                .Where(pd => pd.PizzaId == pizzaId)
                .ToList();

            List<int> toppingIds = new List<int>();
            foreach (var item in pizzaDetailByPizzaId) {
                toppingIds.Add(item.ToppingId);
            }

            return await MyMenuContext.Topings
                .Where(item => toppingIds.Contains(item.ToppingId))
                .ToListAsync();
        }        

        public void DeleteToppingsFromPizza(int pizzaId, int toppingId)
        {

            IEnumerable<PizzaDetails> pizzaDetailToRemoved = MyMenuContext.PizzaDetails
                .Where(pd => pd.PizzaId == pizzaId && pd.ToppingId == toppingId)
                .ToList();

            MyMenuContext.PizzaDetails.Remove(pizzaDetailToRemoved.FirstOrDefault());                
        }

        private MyMenuContext MyMenuContext
        {
            get { return Context as MyMenuContext; }
        }
    }
}
