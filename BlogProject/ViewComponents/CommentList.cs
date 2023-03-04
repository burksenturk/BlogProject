using BlogProjectUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProjectUI.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()   //deneme amaçlı static bi yapı kurdum
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    UserName = "Şevval"
                },
                new UserComment
                {
                    Id=2,
                    UserName = "Kerem"
                },
                new UserComment
                {
                    Id = 3,
                    UserName = "Ayaz"
                }
            };
            return View(commentvalues);
        }
    }
}

