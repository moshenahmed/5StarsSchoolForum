using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _5StarsSchoolForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _5StarsSchoolForum.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            var model = (from cat in db.Categories
                         from mes in cat.UserMessages
                         join Message in db.Messages on mes.CategoryId equals
                         Message.Id

                         select new CategoryMessageViewModel()
                         {
                             CatTitle = cat.CategoryTitle,
                             Title = mes.Title,
                             PostMessage = mes.PostMessage,
                             PostingDate = mes.PostingDate,
                             //MessageReply=mes.Replies.


                         }).ToList();
            return View(model);
        }
        public ActionResult CategoryList()
        {
            var model = db.Categories.ToList();
            return View("SelectCategories", model);
        }

        // GET: Categories/Details/5
        public ActionResult Studentlist()

        {

            //var a = db.Users.ToList()[0].Roles.ToList()[0].RoleId == model.ToList()[0].Id;
            var model = (from user in db.Users
                         from userRole in user.Roles
                         join role in db.Roles on userRole.RoleId equals
                         role.Id

                         select new UserViewModel()
                         {
                             Username = user.UserName,

                             Role = role.Name
                         }).ToList();

            return View("Studentlist", model);
        }
        public ActionResult Teacherlist()

        {
            var model = db.Roles.Where(n => n.Name == "Teacher");
            return View("Teacherlist", model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);


            if (category == null)
            {
                return HttpNotFound();
            }
            var model = db.Categories.Where(v => v.Id == category.Id).ToList();
            return View(model);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Id,CategoryTitle,Messages.PostMessage")]*/ CategoryMessageViewModel model)
        {

            if (ModelState.IsValid)
            {
                var category = new Category();
                {
                     category.CategoryTitle= model.CatTitle ;


                };
                db.Categories.Add(category);
                
                var mess = new Message();
                 mess.Title= model.Title;
                 mess.PostMessage= model.PostMessage ;
                mess.PostingDate = DateTime.Now;
                model.PostingDate = mess.PostingDate;
                db.Messages.Add(mess);
                db.SaveChanges();
                return RedirectToAction("Index");

            }


            return View(model);


        }

            
     

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateReply(int? id)
        {
            //var model = (from m in db.Messages
            //             from mr in db.Replies
            //             join reply in db.Replies on mr.MessageId equals
            //             reply.Id

            //             select new Reply()
            //             {
            //                 ReplyMessage = mr.ReplyMessage,

            //                 PostingTime = mr.PostingTime
            //             }).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
            //return View("Reply", model);
        }
        [HttpPost]
        public ActionResult CreateReply(int id)
        {
           
            
                var rep = new Reply();
                var cat = db.Categories.Find(id);
                var mes = db.Messages.Where(x => x.Id == cat.Id).ToString();
               

                rep.PostingTime = DateTime.Now;
                rep.MessageId = int.Parse(mes);

                db.Replies.Add(rep);
                db.SaveChanges();
            
            return View("Reply");
           
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}