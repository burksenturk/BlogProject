using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesslayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System;
using X.PagedList;
using FluentValidation.Results;

namespace BlogProjectUI.Areas.Admin.Controllers
{
    [Area("Admin")] //bu controllerda olusturmus oldugum actionların area dan geldiğini programa bildirmiş oldum.
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());  
        public IActionResult Index(int page = 1)
        {
            var values = cm.Getlist().ToPagedList(page,3);  //page değişkeninden gelen değerle başlıcak sayfalama işlemi(1),her sayfada 3 değer olacak
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult  AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p); 
            if (results.IsValid)

            {
                //writerAbout ve status u controller tarafından gönderiyorum boş geçmemek adına
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");
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
        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
