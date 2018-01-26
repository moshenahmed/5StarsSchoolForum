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
        public int Usersid { get; set; }
        public int RepliesId { get; set; }
        public string Title { get; set; }
        public string PostMessage { get; set; }
        public Reply Reply { get; set; }
        [DisplayName("Posting time")]

        [Column(TypeName = "datetime2")]
        public DateTime PostingDate { get; set; }

        public ICollection<Reply> Replies { get; set; }
        [ForeignKey("UsersId")]
        public ICollection<ApplicationUser> users { get; set; }



    }
}
