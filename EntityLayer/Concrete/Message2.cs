﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message2  //ilişkilendirmeler için olusturduk message-yazar  //bir tabloda iki tane ilişkiolacak
    {
        [Key]
        public int MessageID { get; set; }
        public int? SenderID { get; set; }   
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public Writer SenderUser { get; set; }  //SenderWriter       Bu iki property bize yazarları gösteriyor
        public Writer ReceiverUser { get; set; } //ReceiverWriter 

    }
}
