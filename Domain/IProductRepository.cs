using System.Collections.Generic;

namespace Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
