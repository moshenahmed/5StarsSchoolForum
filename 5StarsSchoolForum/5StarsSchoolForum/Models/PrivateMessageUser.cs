using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class PrivateMessageUser
    {
        public int PMID { get; set; }
        public int UserID { get; set; }
        public DateTime LastViewDate { get; set; }
        public bool IsArchived { get; set; }
    }
}