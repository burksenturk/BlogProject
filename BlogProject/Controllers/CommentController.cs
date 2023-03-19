using BusinessLayer.Concrete;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogProjectUI.Controllers
{
    [AllowAnonymous]
	public class CommentController : Controller
	{
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
        [HttpPost]
        public bool PartialAddComment(Comment p)
        {
            p.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogID = 3;
            cm.CommentAdd(p);
            return true;
        }

        public PartialViewResult CommentListByBlog(int id)  //blogdaki yorum listesi
        {
			var values = cm.Getlist(id);
            return PartialView(values);
        }
    }
}
