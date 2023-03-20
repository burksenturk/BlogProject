using DataAccesslayer.Abstract;
using DataAccesslayer.Concrete;
using DataAccesslayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendboxWithMessageyByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2s.Include(x=>x.ReceiverUser).Where(y=>y.SenderID==id).ToList();
            }
        }

        public List<Message2> GetInboxWithMessageyByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }     
}
