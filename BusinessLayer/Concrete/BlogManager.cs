using BusinessLayer.Abstract;
using DataAccesslayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}
		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetlistWithCategory();
		}
        public List<Blog> GetlistWithCategoryByWriteBm(int id)
        {
            return _blogDal.GetlistWithCategoryByWriter(id);
        }
        public Blog TGetById(int id)
		{
			return _blogDal.GetByID(id);   //silme işlemiiçin kullanmaya başladık
		}
		public List<Blog> GetBlogByID(int id)  //id ye göre blog getir  NOT: bu metodu Iblogservice den implemente etmedim
		{
			return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public List<Blog> Getlist()
		{
			return _blogDal.GetListAll();
		}
		public List<Blog> Getlast3Blog() //footer içinde son 3 blog gönderisini listeleme metodu.. service de yazmadan managerde yazdık...
		{
			return _blogDal.GetListAll().Take(3).ToList();
		}

		public List<Blog> GetBloglistByWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterID == id); 
        }

		public void TAdd(Blog t)
		{
			_blogDal.Insert(t);
		}

		public void TDelete(Blog t)
		{
			_blogDal.Delete(t);
		}

		public void TUpdate(Blog t)
		{
			_blogDal.Update(t);
		}
	}
}
