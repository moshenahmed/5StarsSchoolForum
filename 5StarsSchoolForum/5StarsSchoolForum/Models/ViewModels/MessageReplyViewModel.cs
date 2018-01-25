using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;



namespace _5StarsSchoolForum.Models.ViewModels
{
    public class MessageReplyViewModel
    {
       public int Id { get; set; }
        public string Title { get; set; }
        [DisplayName("MessageToPost")]
        public string PostMessage { get; set; }
        [DisplayName("PostedDateTime")]
        public String PostedBy { get; set; }

        public string UserId { get; set; }
        //public int CategoryId { get; set; }

        public MessageReplyViewModel()
        { }

        public MessageReplyViewModel(Message mes,ApplicationUser user)
        {
            Title = mes.Title;
            PostMessage = mes.PostMessage;
            PostedBy = mes.PostedBy;
            UserId = user.UserName;
          

        }
        



    }
}