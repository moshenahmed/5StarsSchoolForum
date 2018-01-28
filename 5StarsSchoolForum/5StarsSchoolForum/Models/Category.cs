using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Category_Name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Checked { get; set; }

        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }
    }
}