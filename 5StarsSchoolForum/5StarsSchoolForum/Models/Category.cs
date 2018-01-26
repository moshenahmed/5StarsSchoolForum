using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Category 
    {
        public  int Id { get; set; }
        public int Usersid { get; set; }
        public string CategoryTitle { get; set; }
        public Message Messages { get; set; }

        public bool Checked { get; set; }
        [ForeignKey("Usersid")]
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }   
}