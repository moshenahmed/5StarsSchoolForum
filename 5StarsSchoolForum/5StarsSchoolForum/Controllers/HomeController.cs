using _5StarsSchoolForum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Provider;

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

        [HttpGet]
        public ActionResult Assign(string id)
        {            
                var category = db.UserCategoryAssignees.First(x => x.ApplicationUser.Id == id);
                var model = from c in db.Categories
                    where c.Id != category.CategoryId
                    select new AssignCategoryView
                    {
                        Category = c.CategoryTitle
                    };
                return View("AssignCategoryView", model);
        }

        [HttpPost]
        public ActionResult Assign(string category, string id)
        {
            var model = new UserCategoryAssigned();
            var categoryAssigned = db.Categories.First(x => x.CategoryTitle == category);
            var result = db.UserCategoryAssignees.Where(x =>
                x.CategoryId == categoryAssigned.Id && x.ApplicationUser.Id == id && x.Assigned == false);
            var user = db.Users.First(x => x.Id == id);
          
            if (result != null)
            {
                model.CategoryId = categoryAssigned.Id;
                model.ApplicationUser = user;
                model.Assigned = true;
                db.UserCategoryAssignees.AddOrUpdate(model);
                db.SaveChanges();
            }

            var modeltwo = new AssignedCategoryView
            {
                Category = model.Category.CategoryTitle,
                Usertag = model.ApplicationUser.UserName
            };

            return View("AssignedCategoryView", modeltwo);
            
        }

        public ActionResult AssignedCategories(string id)
        {
            var categories = (from c in db.UserCategoryAssignees
                where c.ApplicationUser.Id == id && c.Assigned == true
                join g in db.Categories on
                    c.CategoryId equals g.Id
                select new CategoryListViewModel
                {
                    CategoryAssigned = g.CategoryTitle
                }).ToList();
           
            return View("UserAssignedCategories", categories);
        }

       
        public ActionResult Unassign(string cat, string id)
        {
            var catid = db.Categories.First(x => x.CategoryTitle == cat).Id;
            var user = db.UserCategoryAssignees.First(x => x.ApplicationUser.Id == id).ApplicationUser;
            var assignedCategory = db.UserCategoryAssignees.First(x =>
                x.ApplicationUser.Id == id && x.Assigned == true && x.CategoryId == catid);

            assignedCategory.ApplicationUser.Id = id;
            assignedCategory.CategoryId = catid;
            assignedCategory.Assigned = false;

            db.Entry(assignedCategory).State = EntityState.Modified;
            db.SaveChanges();

            var model = db.UserCategoryAssignees.Where(x => x.ApplicationUser.Id == id).Where(v => v.Assigned == true)
                .Where(m => m.CategoryId == catid).ToList();

            return View();

        }
    }
}