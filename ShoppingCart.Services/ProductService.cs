using ShoppingCart.Entities;
using ShoppingCart.Repositories;
using System.Collections.Generic;

namespace ShoppingCart.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public Product SaveProduct(Product product)
        {
            return _productRepository.SaveProduct(product);
        }

        public bool UpdateProduct(int id, Product product)
        {
            return _productRepository.UpdateProduct(id, product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetProducts(int categoryId)
        {
            return _productRepository.GetProducts(categoryId);
        }
    }
}
