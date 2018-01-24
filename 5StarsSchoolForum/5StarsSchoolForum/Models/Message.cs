using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class Message
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string PostMessage { get; set; }
        public DateTime PostingDate { get; set; }

        public string UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public ICollection<Reply> replies { get; set; }
        public virtual Category Category { get; set; }
    }
}