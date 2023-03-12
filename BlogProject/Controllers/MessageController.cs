using BusinessLayer.Concrete;
using DataAccesslayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BlogProjectUI.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IActionResult InBox()  //Gelen mesajlar 
        {
            int id = 2;
            var values = mm.GetInboxlistByWriter(id);
            return View(values);
        }
        public IActionResult MessageDetails(int id) //sayfa yüklendiği zaman sen bana verileri bi getir (mesajları aç için)
        {
            var value = mm.TGetById(id);
            return View(value);

        }
    }

}
