using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetInboxWithMessageyByWriter(int id);
        List<Message2> GetSendboxWithMessageyByWriter(int id);
    }
}
