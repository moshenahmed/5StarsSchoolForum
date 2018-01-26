using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class NewPost
    {
        public string Title { get; set; }
        public string FullText { get; set; }
        public bool IncludeSignature { get; set; }
        public int ItemID { get; set; }
        public bool CloseOnReply { get; set; }
        public bool IsPlainText { get; set; }
        public bool IsImageEnabled { get; set; }
        public int ParentPostID { get; set; }
    }
}