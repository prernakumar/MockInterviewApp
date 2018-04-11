using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MockInterviewApp.Models;
using Owin;


[assembly: OwinStartupAttribute(typeof(MockInterviewApp.Startup))]
namespace MockInterviewApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }




        public void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                //create Admin role
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                //create default admin
                var user = new ApplicationUser();
                user.FirstName = "Admin";
                user.LastName = "Admin";
                user.UserName = "admin@test.com";
                user.Email = "admin@test.com";
                user.PhoneNumber = "123-456-7890";
                string pwd = "Qwerty@1234";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }

            }
        }
    }
}