using BlogProjectUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProjectUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index() //bu action kategorilerin grafik üzerinde listeleneceği action olacak
        {
            return View();
        }
            
        public IActionResult CategoryChart() //verilerime static olarak değer atamamı sağlayan metot tanımlıcaz burada
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                Categoryname="Teknoloji",
                CategoryCount=10
            });
            list.Add(new CategoryClass
            {
                Categoryname = "Yazılım",
                CategoryCount = 15
            });
            list.Add(new CategoryClass
            {
                Categoryname = "Spor",
                CategoryCount = 20
            });
            return Json(new { jsonlist = list });                 //geriye json döncez nedeni chartları json formatında bir script ile çağırıcam
        }
    }
}
