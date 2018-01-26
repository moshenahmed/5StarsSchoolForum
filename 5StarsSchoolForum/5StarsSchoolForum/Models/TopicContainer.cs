using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class TopicContainer
    {
        public Forum Forum { get; set; }
        public Topic Topic { get; set; }
        public List<Post> Posts { get; set; }
        public PagerContext PagerContext { get; set; }
        public ForumPermissionContext PermissionContext { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsFavorite { get; set; }
        public Dictionary<int, string> Signatures { get; set; }
        public Dictionary<int, int> Avatars { get; set; }
        public List<int> VotedPostIDs { get; set; }
    }
}