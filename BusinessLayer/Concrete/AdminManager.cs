using DataAccesslayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminDal
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Delete(Admin t)
        {
            throw new NotImplementedException();
        }

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetListAll(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Admin t)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin t)
        {
            throw new NotImplementedException();
        }
    }
}
