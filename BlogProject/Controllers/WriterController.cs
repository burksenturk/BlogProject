using BlogProjectUI.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BlogProjectUI.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager vm = new WriterManager(new EfWriterRepository());
        
        public IActionResult Index()
        {
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var Writervalues = vm.TGetById(1);
            return View(Writervalues);
        }
        [AllowAnonymous]
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
