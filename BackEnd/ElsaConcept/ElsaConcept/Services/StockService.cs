using ElsaConcept.Interfaces;
using ElsaConcept.Models;
using ElsaConcept.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Services
{
    public class StockService : IStockService
    {
        private IGenericRepository<Stock> _StockRepository;

        public StockService(IGenericRepository<Stock> StockRepository)
        {
            _StockRepository = StockRepository;
        }

        public async Task<Stock> AddAsync(Stock Stock)
        {
            return await _StockRepository.AddAsync(Stock);
        }
        public async Task<Stock> UpdateAsync(Stock Stock, int id)
        {
            IEnumerable<Stock> Stocks = _StockRepository.GetAll();
            Stock StockO = Stocks.FirstOrDefault(i => i.Id == id);
            StockO.Name = Stock.Name;
            return await _StockRepository.UpdateAsync(StockO);
        }
        public void Delete(int id)
        {
            Stock Stock = FindById(id);
            _StockRepository.Delete(Stock);
        }

        public IQueryable<Stock> GetAllStocks()
        {
            return _StockRepository.GetAll();
        }

        public Stock FindById(int id)
        {
            IEnumerable<Stock> Stocks = _StockRepository.GetAll();
            Stock Stock = Stocks.FirstOrDefault(i => i.Id == id);

            return Stock;
        }
    }
}
