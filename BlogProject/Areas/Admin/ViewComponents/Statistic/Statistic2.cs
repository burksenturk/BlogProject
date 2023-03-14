using DataAccesslayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjectUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).FirstOrDefault();
            //ViewBag.v3 = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogContent).FirstOrDefault();
            return View();
        }
    }
}
