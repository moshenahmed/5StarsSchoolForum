using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class UserCategoryAssigned
    {
        public int Catid { get; set; }
        public string UserId { get; set; }
        public bool Assigned { get; set; }
        //public virtual ICollection<Category> Category { get; set; }
        //public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}