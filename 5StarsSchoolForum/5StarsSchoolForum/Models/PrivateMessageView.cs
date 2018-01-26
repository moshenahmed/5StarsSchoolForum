using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class PrivateMessageView
    {
        public PrivateMessage PrivateMessage { get; set; }
        public List<PrivateMessagePost> Posts { get; set; }
    }
}