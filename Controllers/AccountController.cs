

//namespace Closer.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly string demoUsername = "admin";
//        private readonly string demoPassword = "1234";

//        [HttpGet]
//        public IActionResult SignIn() => View();

//        [HttpPost]
//        public IActionResult SignIn(LoginViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                if (model.Username == demoUsername && model.Password == demoPassword)
//                {
//                    HttpContext.Session.SetString("Username", model.Username);
//                    return RedirectToAction("Index", "Home");
//                }

//                ModelState.AddModelError("", "Invalid username or password");
//            }

//            return View(model);
//        }

//        public IActionResult Logout()
//        {
//            HttpContext.Session.Clear();
//            return RedirectToAction("SignIn");
//        }

//        [HttpGet]
//        public IActionResult ForgotPassword()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                TempData["Message"] = "If this email exists, a password reset link will be sent.";
//                return RedirectToAction("SignIn");
//            }

//            return View(model);
//        }
//    }
//}



using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Closer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Closer.Domain.Interface;

namespace Closer.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult SignIn() => View();

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _accountService.ValidateUserAsync(model))
                {
                    HttpContext.Session.SetString("Username", model.Username);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "If this email exists, a password reset link will be sent.";
                return RedirectToAction("SignIn");
            }

            return View(model);
        }
    }
}


