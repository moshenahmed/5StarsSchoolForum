using System;
using Microsoft.Owin;
using Owin;
using _5StarsSchoolForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(_5StarsSchoolForum.Startup))]
namespace _5StarsSchoolForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //schoolRolesandUsers();
        }

        //// In this method we will create default User roles and Admin user for login
        //private void schoolRolesandUsers()
        //{

        //    ApplicationDbContext context = new ApplicationDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            
            
            
        //    //throw new NotImplementedException();
        //}

         
       


    }
}
