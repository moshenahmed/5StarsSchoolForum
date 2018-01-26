using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class public_class_VotePostContainer
    {
        public int PostID { get; set; }
        public int Votes { get; set; }
        public Dictionary<int, string> Voters { get; set; }
    }
}