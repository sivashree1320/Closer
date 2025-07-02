using Closer.Data;
using Closer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace Closer.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
       


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Kids()
        {
            return View();

        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Message submitted successfully!";
                return RedirectToAction("Contact");
            }

            return View(message);
        }
    }
}
    


       



