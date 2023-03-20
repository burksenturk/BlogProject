using BusinessLayer.Concrete;
using DataAccesslayer.Concrete;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjectUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;    //BUNA BAK Bİ AŞAĞIDAKİ KOD BLOGUNU TEK SATIRA DÜŞÜREBİLİRSİN SOLİD İÇİN

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public  IActionResult  InBox()  //Gelen mesajlar 
        {
            //var enteredUsers = await _userManager.FindByIdAsync(User.Identity.Name);
            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxlistByWriter(writerID);
            return View(values);
        }
        public IActionResult  SendBox()
        {
            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendboxlistByWriter(writerID);
            return View(values);
        }
        public IActionResult MessageDetails(int id) //sayfa yüklendiği zaman sen bana verileri bi getir (mesajları aç için)
        {
            var value = mm.TGetById(id);
            return View(value);

        }
        public async Task<List<AppUser>> GetUsersAsync()  //DB' ye gidip Users tablosundan kullanıcıları listeleyen bir metod yazdım. aşağıda kullandım
        {
            using (var context = new Context())
            {
                return await context.Users.ToListAsync();
            }
        }
        [HttpGet]
        public async Task<IActionResult>  SendMessage()
        {
            List<SelectListItem> recieverUsers = (from x in await GetUsersAsync()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.UserName.ToString(),
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.reciever = recieverUsers;
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID=writerID;
            p.ReceiverID = 4;
            p.MessageStatus=true;
            p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("InBox");
        }
    }

}
