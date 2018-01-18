using _5StarsSchoolForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5StarsSchoolForum.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LoginStudent()
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View("~/Views/Account/LoginStudent.cshtml");
        }

        /// <summary>
        /// Ayman making post Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // Post: 
        public ActionResult AddStudent(ApplicationUser student)
        {
            var model = db.Users.Where(n => n.UserName == student.UserName).ToList();
            model.Add(student);
            return View(model);
        }
    }
}
