using CpApp.Data;
using CpApp.Interfaces;
using CpApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CpApp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected CpAppContext _context;
        public GenericRepository(CpAppContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


    }
}
