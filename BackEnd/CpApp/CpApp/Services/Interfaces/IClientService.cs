using CpApp.Models;
using CpApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CpApp.Services.Interfaces
{
    public interface IClientService
    {
        IQueryable<User> GetAllClient();
        Task<User> AddAsync(User c);
        Task<User> UpdateAsync(User c, int id);
        void Delete(int id);
        User FindById(int id);
    }
}
