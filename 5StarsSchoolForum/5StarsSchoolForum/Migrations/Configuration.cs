namespace _5StarsSchoolForum.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_5StarsSchoolForum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_5StarsSchoolForum.Models.ApplicationDbContext";
        }

        protected override void Seed(_5StarsSchoolForum.Models.ApplicationDbContext context)
        {
          
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Teacher"), new IdentityRole("Student"));
            context.SaveChanges();

            UserStore<ApplicationUser> userStore = new
                UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(userStore);
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Teacher@schoolforum.com",

                Email = "Teacher@schoolforum.com",
                FirstName = "Anna",
                LastName = "Teacher",
                Gender = "Female",
                Role = "Teacher"

            };
            ApplicationUser user2 = new ApplicationUser()
            {
                UserName = "Student@schoolforum.com",

                Email = "Student@schoolforum.com",
                FirstName = "James",
                LastName = "Student",
                Gender = "Male",
                Role = "Student"

            };
            var result = userManager.Create(user, "Student123/");
            var result2 = userManager.Create(user2, "Student123/");

            ApplicationUser Admin =
                 userManager.FindByName("Teacher@schoolforum.com");
            userManager.AddToRole(Admin.Id, "Teacher");
            context.SaveChanges();

            ApplicationUser Student =
                userManager.FindByName("Student@schoolforum.com");
            userManager.AddToRole(Student.Id, "Student");
            context.SaveChanges();


        }
    }
}
