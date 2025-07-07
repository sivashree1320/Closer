

using Closer.Domain.Models;

namespace Closer.Domain.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();

        
    }
}
