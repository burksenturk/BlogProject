using BusinessLayer.Concrete;
using DataAccesslayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.Getlast3Blog();
            return View(values);
        }
    }
}
