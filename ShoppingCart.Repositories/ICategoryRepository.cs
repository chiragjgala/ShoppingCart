using ShoppingCart.Entities;
using System.Collections.Generic;

namespace ShoppingCart.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
    }
}
