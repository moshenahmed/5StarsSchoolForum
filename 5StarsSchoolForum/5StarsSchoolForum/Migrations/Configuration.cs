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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Teacher"), new IdentityRole("Student"));
            context.SaveChanges();

            UserStore<ApplicationUser> userStore = new
                UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(userStore);
            ApplicationUser user = new ApplicationUser()
            {
                UserName= "studentadmin",
                
                Email="student@student.com",
                Age="45",
                Gender="Male",
                
                
                
                
                
            };
           var result =  userManager.Create(user, "Student123/");
            ApplicationUser Admin =
                 userManager.FindByName("studentadmin");
            userManager.AddToRole(Admin.Id, "Teacher");
            context.SaveChanges();



        }
    }
}
