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

        public  int Id { get; set; }
        //public int UsertagId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string PostMessage { get; set; }
        
        [DisplayName("Posting time")]

        [Column(TypeName = "datetime2")]
        public DateTime PostingDate { get; set; }
        public string user { get; set; }

        //[ForeignKey("RepliesId")]
        public virtual ICollection<Reply> Replies { get; set; }
        //[ForeignKey("UsersTagId")]
        public virtual ApplicationUser UsersTag { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }



    }
}
