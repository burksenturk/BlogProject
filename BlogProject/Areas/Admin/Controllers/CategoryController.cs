using BusinessLayer.Concrete;
using DataAccesslayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Areas.Admin.Controllers
{
    [Area("Admin")] //bu controllerda olusturmus oldugum actionların area dan geldiğini programa bildirmiş oldum.
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());  
        public IActionResult Index()
        {
            var values = cm.Getlist();
            return View(values);
        }
    }
}
