using BlogProjectUI.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesslayer.Concrete;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjectUI.Controllers
{
    
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        WriterManager vm = new WriterManager(new EfWriterRepository());

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

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
        public  async Task<IActionResult>   WriterEditProfile()  //mimariden kurtarıp tamamen Identity e tasıdık
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);        //Name=Useername   ismi yakalıyor
            UserupdateViewModel model = new UserupdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>  WriterEditProfile(UserupdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.mail;
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.UserName = model.username;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,model.password);
            var result = await _userManager.UpdateAsync(values);  //identity kullaranak onun metotları ile güncelleme işlemi yapar
            return RedirectToAction("Index", "Dashboard");
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
