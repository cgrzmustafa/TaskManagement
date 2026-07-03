using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}
