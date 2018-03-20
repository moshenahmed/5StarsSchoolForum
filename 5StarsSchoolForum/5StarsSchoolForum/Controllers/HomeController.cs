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
        private ApplicationDbContext db = new ApplicationDbContext();
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
public ActionResult Assign()
        {
            var model = (from c in db.Categories select new AssignCategoryView
            {
                Category=c.CategoryTitle,
                Assign=false
                
            }).ToList();
            return View("AssignCategoryView", model);
        }
       
       
    } 
}