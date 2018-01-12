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

        // In this method we will create default User roles and Admin user for login   
        private void schoolRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("SeniorTeacher"))
            {

                // first we create Admin rool  
                var role = new IdentityRole();
                role.Name = "SeniorTeacher";
                roleManager.Create(role);
             
                //Here we create a Admin super user who will maintain the website   

                var user = new ApplicationUser();
                user.UserName = "Anna";
                user.Email = "AnnaJames@hotmail.com";

                string uPsswd = "S@123";

                var result = UserManager.Create(user,uPsswd);

                if(result.Succeeded)
                {

                    var result1 = UserManager.AddToRole(user.Id, "Teacher");
                }

            }

            // creating Creating Manager role  

            if(!roleManager.RoleExists("Teacher"))
            {
                var role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);

            }

            if(!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);

            }

          
        }

        protected override void Seed(ApplicationDbContext context)
        {

            schoolRolesandUsers();
            //context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Teacher"));

            //UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            //ApplicationUser user = new ApplicationUser()
            //{
            //    UserName = "Sai",
            //    Email = "Teacher@SchoolForum.se",

            //    Age = "10",
            //    Gender = "Female",
            //    Role="Teacher"


            //};

            //var result = userManager.Create(user, "password");

            //ApplicationUser Teacher =
            //    userManager.FindByName("Teacher@SchoolForum.se");
            //userManager.AddToRole(Teacher.Id, "Teacher");
            //context.SaveChanges();

        }
    }
    }

