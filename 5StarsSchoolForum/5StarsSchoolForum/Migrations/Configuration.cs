namespace _5StarsSchoolForum.Migrations
{
    using _5StarsSchoolForum.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_5StarsSchoolForum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
           
        }

        protected override void Seed(_5StarsSchoolForum.Models.ApplicationDbContext context)
        {
            


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Teacher"));
            context.Roles.AddOrUpdate(s => s.Name, new IdentityRole("Student"));
            //creating a defaultuser
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Anna",
                Email = "Teacher@5starschoolforum.se",
                FirstName = "Anna",
                LastName = "Teacher",
                Gender = "Female"

            };

            // Creating a password for the teacher user
            var result = UserManager.Create(user, "password");

            ApplicationUser admin =
                UserManager.FindByName("Teacher@5starschoolforum.se");
            UserManager.AddToRole(admin.Id, "Teacher");
            context.SaveChanges();


        }
    }
}
