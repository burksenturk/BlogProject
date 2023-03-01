using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
