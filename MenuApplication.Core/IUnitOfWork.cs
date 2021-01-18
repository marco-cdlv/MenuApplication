using MenuApplication.Core.Repositories;
using MenuApplication.Core.Respositories;
using System;
using System.Threading.Tasks;

namespace MenuApplication.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPizzaRespository Musics { get; }
        IToppingRepository Artists { get; }
        Task<int> CommitAsync();
    }
}
