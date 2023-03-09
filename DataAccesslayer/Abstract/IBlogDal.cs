using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetlistWithCategory();
        List<Blog> GetlistWithCategoryByWriter(int id); //Blogu kategoriyle beraber getir ama yazar göre getirecek
    }
}
