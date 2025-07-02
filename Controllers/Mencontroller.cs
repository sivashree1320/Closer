using Closer.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Closer.Models;
using System.Collections.Generic;

namespace Closer.Controllers
{
    public class MensController : Controller
    {
        public IActionResult Index()
        {
            // Dummy product list
            var products = new List<MenProduct>
            {
                new MenProduct
                {
                    Id = 1,
                    Name = "Formal White Shirt",
                    ImageUrl = "/images/formals.jpg",
                    Price = 999,
                    Description = "Slim fit cotton formal shirt."
                },
                new MenProduct
                {
                    Id = 2,
                    Name = "Navy Blazer",
                    ImageUrl = "/images/navy blazer.jpg",
                    Price = 2499,
                    Description = "Office wear stylish blazer."
                },
                new MenProduct
                {
                    Id = 3,
                    Name = "Black Jeans",
                    ImageUrl = "/images/black jean.jpeg",
                    Price = 1499,
                    Description = "Stretchable denim black jeans."
                }
            };

            return View(products); // Send data to the view
        }
    }
}
