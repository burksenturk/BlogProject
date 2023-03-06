using BusinessLayer.Concrete;
using DataAccesslayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = abm.Getlist();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
