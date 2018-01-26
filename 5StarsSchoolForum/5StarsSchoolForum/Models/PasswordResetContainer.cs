using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class PasswordResetContainer
    {
        public bool IsValidUser { get; set; }
        public string Password { get; set; }
        public string PasswordRetype { get; set; }
        public string Result { get; set; }
    }
}