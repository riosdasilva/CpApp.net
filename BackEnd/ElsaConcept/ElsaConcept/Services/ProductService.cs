using ElsaConcept.Interfaces;
using ElsaConcept.Models;
using ElsaConcept.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Services
{
    public class ProductService : IProductService
    {
        private IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }
        public async Task<Product> UpdateAsync(Product product, int id)
        {
            IEnumerable<Product> Products = _productRepository.GetAll();
            Product productO = Products.FirstOrDefault(i => i.Id == id);
            productO.Name = product.Name;
            productO.Size = product.Size;
            productO.Stock = product.Stock;
            productO.Category = product.Category;
            return await _productRepository.UpdateAsync(productO);
        }
        public void Delete(int id)
        {
            Product product = FindById(id);
            _productRepository.Delete(product);
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product FindById(int id)
        {
            IEnumerable<Product> Products = _productRepository.GetAll();
            Product product = Products.FirstOrDefault(i => i.Id == id);

            return product;
        }
    }
}
