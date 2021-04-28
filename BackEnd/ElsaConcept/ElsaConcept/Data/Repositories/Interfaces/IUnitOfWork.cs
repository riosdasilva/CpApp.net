using ElsaConcept.Models;
using ElsaConcept.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Clients { get; }
        int Complete();
    }
}
