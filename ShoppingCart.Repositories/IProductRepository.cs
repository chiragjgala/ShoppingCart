using System.Collections.Generic;
using ShoppingCart.Entities;

namespace ShoppingCart.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int categoryId);
        Product GetProduct(int id);
        Product SaveProduct(Product product);
        bool UpdateProduct(int id, Product product);
        void Delete(int id);
        IEnumerable<Product> GetProducts();
    }
}
