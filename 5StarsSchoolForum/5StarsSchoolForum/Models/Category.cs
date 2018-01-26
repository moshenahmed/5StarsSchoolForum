using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5StarsSchoolForum.Models
{
    public class Category
    {
        public int Id { get; set; }

        //[Required]
        //[ForeignKey("TypeId")]
        //public byte TypeId { get; set; }

        [Display(Name="Course Name")]
        [Required(AllowEmptyStrings=false,ErrorMessage="Category Name Required")]
        [StringLength (255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public bool Checked { get; set; }

        [Required]
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Type")]
        public virtual ICollection<Type> Types { get; set; }

       
                   
        //[ForeignKey("ApplicationUserId")]
        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }

        //[ForeignKey("MessageId")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}