using BusinessLayer.Concrete;
using DataAccesslayer.Concrete;
using DataAccesslayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace BlogProjectUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c= new Context();  
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.Getlist().Count();
            ViewBag.v2=c.Contacts.Count();
            ViewBag.v3=c.Comments.Count();

            //hava durumunu api ile alma
            string api = "71218e7f29024fb30d1e16ba7b9ef8c7";  //benim keyim
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //document içinde temperature ı getir sıfırıncı indexteki ,value dan gelen Value değerini al..
            return View();
        }
    }
}
