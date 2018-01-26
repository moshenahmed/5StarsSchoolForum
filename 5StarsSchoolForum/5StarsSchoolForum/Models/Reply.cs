using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Reply // reply
    {

        public int Id { get; set; }
        public string ReplyMessage { get; set; }
        public DateTime PostingTime { get; set; }
        public int MessageId { get; set; }

        //[Column(TypeName = "datetime")]
        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }
    }
}