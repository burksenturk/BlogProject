using BusinessLayer.Concrete;
using DataAccesslayer.Concrete;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProjectUI.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        Context c = new Context(); 
        public IViewComponentResult Invoke()
        {
            //sisteme outantice olan kullanıcıya ait hakknda kısmının gözükmesi..
            var username = User.Identity.Name;
            ViewBag.veri= username;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y=>y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x=>x.WriterMail == userMail).Select(y=>y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerID);
            return View(values);
        }
    }
}
