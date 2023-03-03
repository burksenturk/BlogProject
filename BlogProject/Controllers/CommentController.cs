using BusinessLayer.Concrete;
using DataAccesslayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectUI.Controllers
{
	public class CommentController : Controller
	{
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
        public PartialViewResult CommentListByBlog(int id)  //blogdaki yorum listesi
        {
			var values = cm.Getlist(id);
            return PartialView(values);
        }
    }
}
