using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Views
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
