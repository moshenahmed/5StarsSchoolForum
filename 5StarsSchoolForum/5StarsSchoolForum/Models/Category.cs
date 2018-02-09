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
        
        
        public string CategoryTitle { get; set; }
        

        
        
        public virtual ICollection<ApplicationUser> Users { get; set; }
        //[ForeignKey("UserMessagesid")]
        public virtual ICollection<Message> UserMessages { get; set; }

    }   
}