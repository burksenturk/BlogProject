using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key] // key attiribute ü hangi sütunun birincil anahtar oldugunu belirliyor
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; } //küçük resim
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; } //ilişki içerisine alınacak olan tablo türünde yada entity türünde tanımlanması gerekiyor
        public int WriterID { get; set; }
        public Writer Writer { get; set; } //ilişki içerisine alınacak olan tablo türünde yada entity türünde tanımlanması gerekiyor

        public List<Comment> Comments { get; set; } // bir blogun birden fazla yorumu olabilir mantıgı
    }
}
