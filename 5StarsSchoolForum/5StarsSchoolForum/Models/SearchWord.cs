using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class SearchWord
    {
        public string Word { get; set; }
        public int TopicID { get; set; }
        public int Rank { get; set; }

        public enum SearchType
        {
            Rank,
            Date,
            Title,
            Name,
            Replies
        }
    }
}