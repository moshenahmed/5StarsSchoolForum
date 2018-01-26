using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class PostWithChildren
    {
        public Post Post { get; set; }
        public List<Post> Children { get; set; }
    }
}