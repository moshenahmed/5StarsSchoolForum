using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _5StarsSchoolForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _5StarsSchoolForum.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index(int? id)
        {
            List<CategoryMessViewModel> cm = new List<CategoryMessViewModel>();
            Category c = db.Categories.Find(id);
            foreach (Message mg in db.Messages.Where(m => m.CategoryId == id))
            {
                CategoryMessViewModel categoryMessViewModel = new CategoryMessViewModel();

                categoryMessViewModel.MessageId = mg.Id;
                categoryMessViewModel.Name = c.Name;
                categoryMessViewModel.Title = mg.Title;
                categoryMessViewModel.PostMessage = mg.PostMessage;
                categoryMessViewModel.PostedBy = mg.PostedBy;
                categoryMessViewModel.PostingDate = mg.PostingDate;
                cm.Add(categoryMessViewModel);
            }
            return View(cm);
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create(int? id)
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

            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,PostMessage,PostedBy,PostingDate")] Message message, int? id)
        {


            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser appuser = UserManager.FindById(User.Identity.GetUserId());
            message.PostedBy = appuser.Email;
            message.UserId = appuser.Id;
            message.PostingDate = DateTime.Now;
            Category c = db.Categories.Find(id);
            message.CategoryId = c.Id;
            db.Messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index", "Categories");

        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,PostMessage,PostedBy,PostingDate")] Message message)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(message).Property(p => p.PostingDate).IsModified = false;
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
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
