using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.UI.Controllers.Admin
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
