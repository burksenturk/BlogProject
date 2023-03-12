using BlogProjectUI.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesslayer.Concrete;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace BlogProjectUI.Controllers
{
    
    public class WriterController : Controller
    {

        WriterManager vm = new WriterManager(new EfWriterRepository());
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v=usermail; 
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            //bu işlemler ile yazar id  sini static elle vermeden autantice  işlem ile çekmiş oluyoruz(id getirmek)
            Context c = new Context();
            var usermail = User.Identity.Name;  
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = vm.TGetById(writerID);
            return View(writervalues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            var pas1 = Request.Form["pass1"];
            var pas2 = Request.Form["pass2"]; //şifreyi iki defa sorma işlemi 72.kısım
            if (pas1 == pas2)
            {
                writer.WiterPassword = pas2;
                WriterValidator validationRules = new WriterValidator();
                ValidationResult result = validationRules.Validate(writer);
                if (result.IsValid)
                {
                    vm.TUpdate(writer);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else
            {
                ViewBag.hata = "Girdiğiniz Parolalar Uyuşmuyor!";
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd() // foto ekleme ve admin tarafında kullancaz
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddprofileImage p)
        {
            Writer w = new Writer();
            if(p.WriterImage != null)  //Dosya yüklemek için kullanıyoruz
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFile", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WiterPassword = p.WiterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            vm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");

        }
    }
}
