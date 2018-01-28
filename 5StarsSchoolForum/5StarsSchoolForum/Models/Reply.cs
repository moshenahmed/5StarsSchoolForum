using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Reply 
    {

        public int Id { get; set; }
        [Required]
        public string ReplyMessage { get; set; }
        [Required]
        public String ReplyFrom { get; set; }
      
        [DisplayName("ReplyDateTime")]
        [Column(TypeName = "datetime2")]
        public DateTime PostingTime { get; set; }

        public int MessageId { get; set; }
        public string UserId { get; set; }


        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}