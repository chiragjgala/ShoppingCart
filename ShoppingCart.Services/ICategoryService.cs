using ShoppingCart.Entities;
using System.Collections.Generic;

namespace ShoppingCart.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
    }
}
