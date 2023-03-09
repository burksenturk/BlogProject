using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogProjectUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BloglistByWriter()
        {
            var values = bm.GetlistWithCategoryByWriteBm(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()  //yazarın blog eklmesi iççin yaptık
        {
            //dropdown olusturduk
            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p) //yazarın blog eklmesi iççin yaptım
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p); //controlü sağlıyor //ValidationResult ctrl+. yaparken fluent i seç dataannotion değil
           
            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            if (results.IsValid)

            {
                //writerAbout ve status u controller tarafından gönderiyorum boş geçmemek adına
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //model durumuna bi tane hata ekleyeceksin nedir bu hata( hatayı veren property,hatanın kendisi..)
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id) //sayfa yüklendiği zaman sen bana verileri bi getir
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.Getlist()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {         
            //p.WriterID=1;
            //p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
