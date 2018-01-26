using _5StarsSchoolForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_5StarsSchoolForum.Startup))]
namespace _5StarsSchoolForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleTeacher = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserTeacher = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleTeacher.RoleExists("Admin"))
            {

                // first we create Teacher rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Teacher";
                roleTeacher.Create(role);

                //Here we create a Teacher as an Adminstrator super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "Swapna";
                user.Email = "swapnapusuleti@gmail.com";

                string userPWD = "S@L7300811";

                var chkUser = UserTeacher.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserTeacher.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!UserTeacher.RoleExists("Teacher"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Teacher";
                UserTeacher.Create(role);

            }

            // creating Creating Employee role    
            if (!UserTeacher.RoleExists("Student"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Student";
                UserTeacher.Create(role);

            }
        }
    }
}