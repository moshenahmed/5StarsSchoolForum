using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Message
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DisplayName("MessageToPost")]
        public string PostMessage { get; set; }
        public String PostedBy { get; set; }
        [DisplayName("PostedDateTime")]
         public DateTime PostingDate { get; set; }

        public string UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual List<Reply> replies { get; set; }
        public virtual Category Category { get; set; }


        public Message()
        {
            replies = new List<Reply>();
        }
    }
}