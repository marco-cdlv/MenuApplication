using MenuApplication.Core.Repositories;
using MenuApplication.Core.Respositories;
using System;
using System.Threading.Tasks;

namespace MenuApplication.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPizzaRespository Pizzas { get; }
        IToppingRepository Toppings { get; }
        IPizzaDetailRespository PizzaDetails { get; }
        Task<int> CommitAsync();
    }
}
