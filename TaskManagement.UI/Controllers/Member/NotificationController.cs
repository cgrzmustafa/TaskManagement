using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.UI.Controllers.Member
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
