using Closer.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Closer.Controllers
{
    public class MenController : Controller
    {
        private readonly IProductService _productService;

        public MenController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products); // Make sure you have a View for this
        }
    }
}
