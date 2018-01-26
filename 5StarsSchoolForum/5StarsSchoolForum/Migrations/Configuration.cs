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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_5StarsSchoolForum.Models.ApplicationDbContext context)
        {
            //if (!context.Roles.Any(t => t.Name == "teacher"))
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    roleManager.Create(new IdentityRole { Name = "teacher" });
            //}

            if (!context.Users.Any(r => r.UserName == "teacher@5starschoolforum.se"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);


                var user = new ApplicationUser()
                {
                    UserName = "userTeacher",
                    Email = "teacher@5starschoolforum.se",
                    FirstName = "Anna",
                    LastName = "Teacher",
                    Gender = "Female",
                    Role = "Teacher"

                };


                userManager.Create(user, "Password10");
                roleManager.Create(new IdentityRole { Name = "teacher" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "teacher");
            }



            if (!context.Users.Any(s => s.UserName == "student@5starschoolforum.se"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);


                var user = new ApplicationUser()
                {
                    UserName = "userStudent",
                    Email = "student@5starschoolforum.se",
                    FirstName = "sai",
                    LastName = "student",
                    Gender = "Female",
                    Role = "student"

                };


                userManager.Create(user, "password");

                roleManager.Create(new IdentityRole { Name = "student" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "student");
            }



            context.SaveChanges();
        }
    }
}