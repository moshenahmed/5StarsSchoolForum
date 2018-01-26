using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class PagerContext
    {
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}