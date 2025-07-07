
using Closer.Domain.Interface;
using Closer.Domain.Models;

using Microsoft.EntityFrameworkCore;


namespace Closer.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }

    //private static readonly List<Product> _products = new List<Product>
    //    {
    //        new Product { Id = 1, Name = "Effortless Outfit", ImageUrl = "effortless.jpeg", Price = 1000 },
    //        new Product { Id = 2, Name = "Cosy", ImageUrl = "cosy.jpeg", Price = 1200 },
    //        new Product { Id = 3, Name = "Kids", ImageUrl = "kids.jpeg", Price = 800 },
    //        new Product { Id = 5, Name = "Flash", ImageUrl = "flash.jpeg", Price = 900 },
    //    };

    //public Task<List<Product>> GetAllAsync()
    //{
    //    return Task.FromResult(_products);
    //}

    //public Task<List<Product>> SearchAsync(string searchTerm)
    //{
    //    var filtered = string.IsNullOrWhiteSpace(searchTerm)
    //        ? _products
    //        : _products.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
    //    return Task.FromResult(filtered);
    //}
}

