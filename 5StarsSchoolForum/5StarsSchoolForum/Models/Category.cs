using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Category
    {
        public int Id { get; set; }
      
        [Display(Name="Name of the Category")]
        [Required(AllowEmptyStrings=false,ErrorMessage="Category Name Required")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }
    }
}