using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class PostEdit
    {
        public PostEdit() { }

        public PostEdit(Post post)
        {
            Title = post.Title;
            FullText = post.FullText;
            ShowSig = post.ShowSig;
        }

        public string Title { get; set; }
        public string FullText { get; set; }
        public bool ShowSig { get; set; }
        public string Comment { get; set; }
        public bool IsPlainText { get; set; }
    }
}