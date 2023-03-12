using DataAccesslayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProjectUI.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WiterPassword == p.WiterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>   //Autantication işlemleri yani login işlemleri için claim kütüphanesinde yararlandık
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)
                };
                //"a" gibi string biifade girmezsek Eğer string parametre girilmezse  kimlik doğrulama olmadan bir oturum başlatılıyor. Bu sebepten hala sistemde hiçbir sayfayı göremez halde oluyoruz. 
                var userİdentity = new ClaimsIdentity(claims,"a"); 
                ClaimsPrincipal principal = new ClaimsPrincipal(userİdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Dashboard"); //girince bu saydaya yönlendir
            }
            else
            {
                return View();
            }
        }


    }
}

