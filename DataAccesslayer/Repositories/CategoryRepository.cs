﻿using DataAccesslayer.Abstract;
using DataAccesslayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.Repositories
{
    public class CategoryRepository : ICategoryDal
    { 
        Context c = new Context();
        public void AddCategory(Category category)
        {
            c.Add(category); //benden obje türünde bir entity bekliyor ondan dolayı parametre içindeki category gönderdim.
            c.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            c.Remove(category);  // Add,remove,update bunlar ef core kendi metotları..
            c.SaveChanges();
        }

        public Category GetByıd(int id)
        {
            return c.Categories.Find(id);
        }

        public List<Category> ListAllCategory()
        {
            return c.Categories.ToList();
        }

        public void UpdateCategory(Category category)
        {
            c.Update(category);
            c.SaveChanges();
        }
    }
}