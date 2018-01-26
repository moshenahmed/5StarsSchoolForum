using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class UserImage
    {
        public int UserImageID { get; set; }
        public int UserID { get; set; }
        public int SortOrder { get; set; }
        public bool IsApproved { get; set; }
    }
}