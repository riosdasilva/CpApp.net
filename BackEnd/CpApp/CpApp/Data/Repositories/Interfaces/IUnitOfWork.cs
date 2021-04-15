using CpApp.Models;
using CpApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Clients { get; }
        int Complete();
    }
}
