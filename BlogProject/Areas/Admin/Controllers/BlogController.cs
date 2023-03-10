using BlogProjectUI.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccesslayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogProjectUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportSaticExcelBloglist()
        {
            using(var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach(var item in GetBloglist())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount ++;
                }
                using(var stream =new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBloglist()
        {
            List<BlogModel> list = new List<BlogModel>
            {
                new BlogModel{ ID=1,BlogName="C# 101 eğitimine başlangıç"},
                new BlogModel{ ID=2,BlogName="TOGG elektrikli araç"},
                new BlogModel{ ID=3,BlogName="Galatasaray"}
            };
            return list;
        }
        public IActionResult BlogListExcel() //ExportSaticExcelBloglist bu metodu tetiklicek GetBloglist metodundan da verilerini alacak.
        {
            return View();
        }

        public IActionResult  ExporDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma2.xlsx");
                }
            }
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> list2 = new List<BlogModel2>();
            using (var c = new Context())
            {
                list2 = c.Blogs.Select(x => new BlogModel2
                {
                    ID=x.BlogID,
                    BlogName=x.BlogTitle

                }).ToList();

            }
            return list2;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }

}
