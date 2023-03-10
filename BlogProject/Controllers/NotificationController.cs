using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
