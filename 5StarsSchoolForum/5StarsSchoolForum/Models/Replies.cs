using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Replies
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime PostingTime { get; set; }
    }
}