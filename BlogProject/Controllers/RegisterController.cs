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
		public IActionResult Index()   								
		{
			return View();              
        }                               
        [HttpPost]						
		public IActionResult Index(Writer p)  
		{
			WriterValidator wv = new WriterValidator();
			ValidationResult results = wv.Validate(p); //controlü sağlıyor
			if (results.IsValid)
			{
                //writerAbout ve status u controller tarafından gönderiyorum boş geçmemek adına
                p.WriterStatus = true;
                p.WriterAbout = "deneme test";
                wm.TAdd(p);
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
