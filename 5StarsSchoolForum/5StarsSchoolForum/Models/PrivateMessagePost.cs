﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class PrivateMessagePost
    {
        public int PMPostID { get; set; }
        public int PMID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public DateTime PostTime { get; set; }
        public string FullText { get; set; }
    }
}