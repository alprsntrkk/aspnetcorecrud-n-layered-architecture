using BLL.Abstract;
using Dal.Abstract;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository; 
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public bool Delete(string Id)
        {
            return _productRepository.Delete(Id);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetList().ToList();
        }

        public List<Product> SearchByAnyColumn(string queryValue)
        {
            return _productRepository.searchByAnyColumn(queryValue);
        }

        public bool Update(Product product, string Id)
        {
            return _productRepository.Update(product, Id);
        }
    }
}
