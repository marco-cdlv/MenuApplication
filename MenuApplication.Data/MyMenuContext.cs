using MenuApplication.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuApplication.Data
{
    public class MyMenuContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Topings { get; set; }
        public DbSet<PizzaDetails> PizzaDetails { get; set; }
        public DbSet<MenuDetails> MenuDetails { get; set; }


        public MyMenuContext(DbContextOptions<MyMenuContext> options) : base(options)
        {

        }
    }
}
