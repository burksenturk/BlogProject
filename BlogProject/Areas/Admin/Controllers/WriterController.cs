using BlogProjectUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BlogProjectUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller   //ajax işlemleri için olusturdum
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()  //yazar listesi için aşağıdaki listeyi değişkene atayıp bunu da json türüne convertetmem gerekiyor
        {
            var JsonWriters = JsonConvert.SerializeObject(writers);
            return Json(JsonWriters);
        }
        public IActionResult GetByWriterID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x=>x.Id == writerid);
            var JsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(JsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var JsonWriters = JsonConvert.SerializeObject(w);
            return Json(JsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x=>x.Id==w.Id);
            writer.Name = w.Name;
            var JsonWriters = JsonConvert.SerializeObject(w);
            return Json(JsonWriters);
        }



        public static List<WriterClass> writers = new List<WriterClass> //static liste olusturdum
        {
            new WriterClass
            {
                Id=1,
                Name="Burak"
            },
            new WriterClass
            {
                Id=2,
                Name="Murat"
            },
            new WriterClass
            {
                Id=3,
                Name="Bilal"
            }
        };
    }
}
