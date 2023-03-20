using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WiterPassword { get; set; }
        public bool WriterStatus { get; set; }
        public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message2> WriteSender { get; set; }     //MessageSender  Bu iki prop bize aslında mesajları gösteriyor
        public virtual ICollection<Message2> WriteReceiver { get; set; }   //MessageReceiver  Alternatif NOT! HasOne da Writer olmasi gerek cunkü bir yazar birden cok mesaj gonderebilir, WithMany se mesajlarla bagli. 
    }
}
