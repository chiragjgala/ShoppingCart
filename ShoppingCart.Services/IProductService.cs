using ShoppingCart.Entities;
using System.Collections.Generic;

namespace ShoppingCart.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Product SaveProduct(Product product);
        bool UpdateProduct(int id, Product product);
        void Delete(int id);
        IEnumerable<Product> GetProducts(int categoryId);
    }
}
