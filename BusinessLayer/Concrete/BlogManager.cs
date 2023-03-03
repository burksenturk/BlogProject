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

		public void BlogAdd(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogDelete(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogUpdate(Blog blog)
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetlistWithCategory();
		}

		public Blog GetById(int id)
		{
			throw new NotImplementedException();
		}
		public List<Blog> GetBlogByID(int id)  //id ye göre blog getir  NOT: bu metodu Iblogservice den implemente etmedik
		{
			return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public List<Blog> Getlist()
		{
			return _blogDal.GetListAll();
		}
	}
}
