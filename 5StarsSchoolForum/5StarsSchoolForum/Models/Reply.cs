using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Reply
    {
        public Reply(int replyId)
        {
            Id = replyId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int TopicId { get; set; }
        public string IP { get; set; }
        public string ReplyMessage { get; set; }
        public bool IsFirstInTopic { get; set; }
        public string FullText { get; set; }

        //[ForeignKey("ApplicationUserRegistationNumber")]
        //public int ApplicationUserRegistationNumber { get; set; }

        //[ForeignKey("CategoryId")]
        //public int CategoryId { get; set; }

        //[ForeignKey("PostId")]
        public int PostId { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime ReplyTime { get; set; }
        public bool IsEdited { get; set; }
        public string LastEditName { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime LastEditTime { get; set; }
        public bool IsArchived { get; set; }

        //[ForeignKey("MessageId")]
        public virtual ICollection<Message> PostedMessages { get; set; }
        //[ForeignKey("ApplicationUserId")]
        public virtual ICollection<ApplicationUser> PostingMembers { get; set; }
    }
}