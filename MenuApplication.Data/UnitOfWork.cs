﻿using MenuApplication.Core;
using MenuApplication.Core.Repositories;
using MenuApplication.Core.Respositories;
using MenuApplication.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApplication.Data 
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyMenuContext _context;
        private PizzaRepository pizzaRepository;
        private ToppingRepository toppingRepository;

        public UnitOfWork(MyMenuContext context)
        {
            this._context = context;
        }

        IPizzaRespository IUnitOfWork.Musics => pizzaRepository = pizzaRepository ?? new PizzaRepository(_context);

        IToppingRepository IUnitOfWork.Artists => toppingRepository = toppingRepository ?? new ToppingRepository(_context);


        async Task<int> IUnitOfWork.CommitAsync()
        {
            //throw new NotImplementedException();
            return await _context.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {
            //throw new NotImplementedException();
            _context.Dispose();
        }
    }
}
