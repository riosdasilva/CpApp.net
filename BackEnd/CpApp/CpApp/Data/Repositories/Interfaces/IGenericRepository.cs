using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CpApp.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
            Task<T> AddAsync(T entity);
            Task<T> UpdateAsync(T entity);
            IQueryable<T> GetAll();
            IEnumerable<T> Find(Expression<Func<T, bool>> expression);
            void Delete(T entity);

    }

}
