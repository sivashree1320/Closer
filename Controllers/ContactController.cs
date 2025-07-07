
using Closer.Domain.Interface;
using Closer.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Closer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactMessageService _service;

        public ContactController(IContactMessageService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Submit(ContactMessage contactMessages)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.AddMessageAsync(contactMessages); // Await is critical
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                // Log the error (can use ILogger or just temp log for now)
                Console.WriteLine("Error: " + ex.Message);
                return StatusCode(500, new { success = false, message = "Server error" });
            }
        }

    }
}


