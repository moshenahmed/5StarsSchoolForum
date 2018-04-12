using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class UserCategoryAssigned
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public int UserTagId { get; set; }
       
        public bool Assigned { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

      
        public  virtual ApplicationUser ApplicationUser { get; set; }
    }
}