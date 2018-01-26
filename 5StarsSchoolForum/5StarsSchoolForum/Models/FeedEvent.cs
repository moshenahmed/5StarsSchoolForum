using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class FeedEvent
    {
        public int UserID { get; set; }
        public string Message { get; set; }
        public int Points { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}