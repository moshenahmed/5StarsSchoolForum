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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_5StarsSchoolForum.Models.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Teacher"));

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Sai",
                Email = "Teacher@SchoolForum.se",
              
                Age = "10",
                Gender = "Female",
                Role="Teacher"


            };

            var result = userManager.Create(user, "password");

            ApplicationUser Teacher =
                userManager.FindByName("Teacher@SchoolForum.se");
            userManager.AddToRole(Teacher.Id, "Teacher");
            context.SaveChanges();

        }
    }
    }

