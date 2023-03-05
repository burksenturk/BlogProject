﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService
	{
        void BlogAdd(Blog blog);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);
        List<Blog> Getlist();
        Blog GetById(int id);  //güncelleme işleminde kullanıcaz
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBloglistByWriter(int id);  //yazara göre bloglistesini getir

    }
}