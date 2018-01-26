using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5StarsSchoolForum.Models
{
    public class SecurityLogEntry
    {
        public int SecurityLogID { get; set; }
        public SecurityLogType securityLogType { get; set; }
        public int? UserID { get; set; }
        public int? TargetUserID { get; set; }
        public string IP { get; set; }
        public string Message { get; set; }
        public DateTime ActivityDate { get; set; }

        public enum SecurityLogType
        {
            Undefined = 0,
            Login = 1,
            Logout = 2,
            PasswordChange = 3,
            EmailChange = 4,
            FailedLogin = 5,
            UserCreated = 6,
            UserDeleted = 7,
            RoleCreated = 8,
            RoleDeleted = 9,
            UserAddedToRole = 10,
            UserRemovedFromRole = 11,
            UserSessionStart = 12,
            UserSessionEnd = 13,
            NameChange = 14,
            IsApproved = 15,
            IsNotApproved = 16,
            ExternalAssociationSet = 17,
            ExternalAssociationRemoved = 18,
            ExternalAssociationCheckSuccessful = 19,
            ExternalAssociationCheckFailed = 20
        }
    }
}