using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Message
    {

        public int Id { get; set; }
        [Required]
        [DisplayName("MessageTitle")]
        public string Title { get; set; }
        [Required]
        [DisplayName("MessageToPost")]
        public string PostMessage { get; set; }
     
        public String PostedBy { get; set; }
      
        [DisplayName("PostedDateTime")]
        [Column(TypeName = "datetime2")]
        public DateTime PostingDate { get; set; }

        public string UserId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public ICollection<Reply> Replies { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
