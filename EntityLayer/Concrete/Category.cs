﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } 
        public string CategoryDescirption { get; set; }
        public bool CategoryStatus { get; set; } // ilişkili tablolarda silme işlemi problem olusturdugundan dolayı biz bir kategoriyi silmek yerine aktif ya da pasife ceviricez

        public List<Blog> Blogs { get; set; }
    }
}
