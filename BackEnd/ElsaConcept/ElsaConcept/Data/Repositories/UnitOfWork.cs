using ElsaConcept.Interfaces;
using ElsaConcept.Models;
using ElsaConcept.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElsaConceptContext _context;
        public UnitOfWork(ElsaConceptContext context)
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
