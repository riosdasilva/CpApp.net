using ElsaConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Services.Interfaces
{
    public interface IStockService
    {
        IQueryable<Stock> GetAllStocks();
        Task<Stock> AddAsync(Stock c);
        Task<Stock> UpdateAsync(Stock c, int id);
        void Delete(int id);
        Stock FindById(int id);

    }
}
