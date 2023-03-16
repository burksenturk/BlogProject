using BlogProjectUI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProjectUI.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;  //mimariden bağımsız constructure metotlarımı burada kullandım. istesem dahil ederim. kayıt işlemi                                                     yazar üzerinden oalacak
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Index(UserSignUpViewModel p)
        {
            if(ModelState.IsValid) //model de ki kosullar sağlandı ise
            {

                AppUser user = new AppUser()
                {
                    UserName = p.UserName,
                    Email = p.Mail,
                    NameSurname = p.NameSurname
                };
                var result = await _userManager.CreateAsync(user,p.Password);  
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
    }
}
