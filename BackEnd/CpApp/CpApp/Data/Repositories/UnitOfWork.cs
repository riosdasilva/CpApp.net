using CpApp.Interfaces;
using CpApp.Models;
using CpApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CpAppContext _context;
        public UnitOfWork(CpAppContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> Clients { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
