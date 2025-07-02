using Microsoft.AspNetCore.Mvc;
using Closer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Controllers
{
    public class SearchActionController : Controller
    {
        private static readonly List<Product> products = new List<Product>
        {
            new Product { Name = "Effortless Outfit", ImageUrl = "effortless.jpeg", Price = 1000, Id = 1 },
            new Product { Name = "Cosy", ImageUrl = "cosy.jpeg", Price = 1200, Id = 2 },
            new Product { Name = "Kids", ImageUrl = "kids.jpeg", Price = 800, Id = 3 },
            new Product { Name = "Top Brands", ImageUrl = "topbrands.jpeg", Price = 1500, Id = 4 },
            new Product { Name = "Flash", ImageUrl = "flash.jpeg", Price = 900, Id = 5 }
        };

        public IActionResult Index()
        {
            return View();
        }

        // Slight async-style refactor (for larger list in future)
        public async Task<IActionResult> Shop(string searchTerm)
        {
            return await Task.Run(() =>
            {
                var filtered = string.IsNullOrWhiteSpace(searchTerm)
                    ? products
                    : products.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower())).ToList();

                return View(filtered);
            });
        }
    }
}
