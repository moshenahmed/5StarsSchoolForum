using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5StarsSchoolForum.Models
{
    public class CategoryMessViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int MessageId { get; set; }

       

        [Required]
        [DisplayName("Category_Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("MessageTitle")]
        public string Title { get; set; }
        
        public string PostMessage { get; set; }

        [Required]
        public String PostedBy { get; set; }
        [Required]
        [DisplayName("PostedDateTime")]
        [Column(TypeName = "datetime2")]
        public DateTime PostingDate { get; set; }

        


    }
}