using Closer.Domain.Models;


namespace Closer.Domain.Interface
{
    public interface IProductService
    {

       

        Task<List<Product>> GetAllAsync();

        Task<List<Product>> SearchAsync(string searchTerm);
    }
}
