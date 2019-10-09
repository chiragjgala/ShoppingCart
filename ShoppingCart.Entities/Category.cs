using System.Collections.Generic;

namespace ShoppingCart.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
