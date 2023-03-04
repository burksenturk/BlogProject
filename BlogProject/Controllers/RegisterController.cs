using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
			
		[HttpGet]
		public IActionResult Index()   // ÖNEMLİ! EKLEME İŞLEMİ YAPILIRKEN HTTPGET VE HTTPPOST ATTİRUBUTELERİNİN TANIMLANDIGI METOTLARIN İSİMLERİ								AYNI OLMAK ZORUDNADIR
		{
			return View();              //[HttpGet] sayfa yüklenince [HttpPost] buton tetiklenince çalışır
        }                               //[HttpGet] komutu sayfada kategorize veya benzeri işlemler kullanırken sayfa yüklendiği anda istenen									niteliklerde kullanılabilir
        [HttpPost]						//örneğin sayfada il-ilçe seçtiricem kullanıcıya bu il-ilçeyi httpget in altında listelerim
		public IActionResult Index(Writer p)  
		{
			WriterValidator wv = new WriterValidator();
			ValidationResult results = wv.Validate(p); //controlü sağlıyor
			if (results.IsValid)
			{
                //writerAbout ve status u controller tarafından gönderiyorum boş geçmemek adına
                p.WriterStatus = true;
                p.WriterAbout = "deneme test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
            }
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //model durumuna bi tane hata ekleyeceksin nedir bu hata( hatayı veren property,hatanın kendisi..)
				}
			}
			return View();

		}
	}
}
