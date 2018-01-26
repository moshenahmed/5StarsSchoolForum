using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string ReplyMessage { get; set; }
        public DateTime PostingTime { get; set; }
    }
}