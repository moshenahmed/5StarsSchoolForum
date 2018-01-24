using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Message
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string PostMessage { get; set; }

        [DisplayName("Posting time")]
        [Column(TypeName = "datetime2")]
        public DateTime PostingDate { get; set; }
              
        //public int CategoryId { get; set; }

        //public string UserId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<Category> Categories { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }

        [ForeignKey("ReplyId")]
        public virtual ICollection<Reply> Replies { get; set; }

    }
}
