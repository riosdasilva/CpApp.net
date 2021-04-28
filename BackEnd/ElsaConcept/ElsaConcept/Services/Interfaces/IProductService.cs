using ElsaConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Services.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();
        Task<Product> AddAsync(Product p);
        Task<Product> UpdateAsync(Product p, int id);
        void Delete(int id);
        Product FindById(int id);

    }
}
