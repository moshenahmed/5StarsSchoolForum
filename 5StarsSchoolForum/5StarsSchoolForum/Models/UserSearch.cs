using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class UserSearch
    {
        public string SearchText { get; set; }
        public UserSearchType SearchType { get; set; }

        public enum UserSearchType
        {
            Name, Email, Role
        }
    }
}