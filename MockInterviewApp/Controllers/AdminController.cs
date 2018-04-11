using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MockInterviewApp.Models;

namespace MockInterviewApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        internal class InterviewerDetails
        {
            public string FirstName;
            public string LastName;
            public string Email;
            public string UserConfirmedFlag;
        }
        
        // GET: Admin
        public ActionResult Index()
        {
            //var potentialInterviewers = context.Users.AsEnumerable().Where(a => a.UserConfirmedFlag != "True").ToList();
            ViewBag.Model = context.Users.Where(a => a.UserConfirmedFlag != "True");
            //ViewBag.Model = context.Users.AsEnumerable().Where(a => a.UserConfirmedFlag != "True").ToList().FirstOrDefault();
            //ViewBag.pendingRequests = potentialInterviewers.AsEnumerable().Select(a => new InterviewerDetails { FirstName = a.FirstName, LastName = a.LastName, Email = a.Email  });

            
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email)
        {
            // ApplicationUser user = context.Users.Where(u => u.Email.Equals(Email)).FirstOrDefault();
            //var userManager=new
            Console.WriteLine("Email:"+ Email);
            var query = (from q in context.Users
                         where q.Email == Email
                         select q).FirstOrDefault();
            query.UserConfirmedFlag = "True";
            context.SaveChanges();
            //var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            //var manager = new ApplicationUserManager(store);
            //manager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}