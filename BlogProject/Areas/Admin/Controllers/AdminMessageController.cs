using BusinessLayer.Concrete;
using DataAccesslayer.Concrete;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjectUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        Context c = new Context();
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxlistByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendboxlistByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View(Tuple.Create<Message2, AppUser>(new Message2(), new AppUser()));
        }
        [HttpPost]
        public async Task<IActionResult> ComposeMessage([Bind(Prefix = "Item1")] Message2 message, [Bind(Prefix = "Item2")] AppUser writer)
        {
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = await _userManager.FindByEmailAsync(writer.Email);
            message.SenderID = sender.Id;
            message.ReceiverID = receiver.Id;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = true;
            mm.TAdd(message);
            return RedirectToAction("Sendbox");
        }
    }
}
