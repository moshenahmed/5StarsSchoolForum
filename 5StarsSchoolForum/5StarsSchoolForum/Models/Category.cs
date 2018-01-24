using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Checked { get; set; }

       
        //public int MessageId { get; set; }
               
        //public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }

        [ForeignKey("MessageId")]
        public ICollection<Message> Messages { get; set; }

        //[ForeignKey("ReplyId")]
        //public ICollection<Reply> Replies { get; set; }
    }
}