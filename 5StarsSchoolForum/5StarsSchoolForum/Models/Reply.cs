using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Reply
    {

        public int Id { get; set; }

        public string ReplyMessage { get; set; }

        public DateTime PostingTime { get; set; }

        
        //public int MessageId { get; set; }

        
        //public string UserId { get; set; }

        [ForeignKey("MessageId")]
        public virtual ICollection<Message> Messages { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }
    } 
}