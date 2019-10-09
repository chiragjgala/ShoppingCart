using System.Collections.Generic;

namespace ShoppingCart.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();

        void Post(IEnumerable<T> data);
    }
}
