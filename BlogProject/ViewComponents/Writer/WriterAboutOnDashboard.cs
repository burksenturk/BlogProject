using BusinessLayer.Concrete;
using DataAccesslayer.Concrete;
using DataAccesslayer.EntityFramework;
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
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x=>x.WriterMail == usermail).Select(y=>y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerID);
            return View(values);
        }
    }
}
