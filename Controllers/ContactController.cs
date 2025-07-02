using Microsoft.AspNetCore.Mvc;
using Closer.Models;
using Closer.Data;
using System.Threading.Tasks;

namespace Closer.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ContactMessage contactMessages)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(contactMessages);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}
