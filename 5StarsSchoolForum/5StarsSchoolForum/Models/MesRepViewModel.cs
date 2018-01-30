using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5StarsSchoolForum.Models
{
    public class MesRepViewModel
    {
        public int Id { get; set; }

        public int ReplyId { get; set; }
        public int MessageId { get; set; }

        [DisplayName("MessageTitle")]
        public int Title { get; set; }
     
        public String PostedBy { get; set; }
       
        [DisplayName("PostedDateTime")]
        [Column(TypeName = "datetime2")]
        public DateTime PostingDate { get; set; }

        public string ReplyFrom { get; set; }
    
        public string ReplyMessage { get; set; }

        [DisplayName("ReplyDateTime")]
        [Column(TypeName = "datetime2")]
        public DateTime PostingTime { get; set; }

       
      


    }
}