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
    public class RepliesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Replies
        public ActionResult Index(int? id)
        {
            List<MesRepViewModel> mr = new List<MesRepViewModel>();
            Message ms = db.Messages.Find(id);
            foreach (Reply R in db.Replies.Where(m => m.MessageId == id))
            {
                MesRepViewModel mesRepViewModel = new MesRepViewModel();
                mesRepViewModel.ReplyId = R.Id;
                mesRepViewModel.Title= ms.Title;
                mesRepViewModel.PostedBy = ms.PostedBy;
                mesRepViewModel.ReplyFrom = R.ReplyFrom;
                mesRepViewModel.ReplyMessage = R.ReplyMessage;
                mesRepViewModel.PostingDate = ms.PostingDate;
                mesRepViewModel.PostingTime = R.PostingTime;
                mr.Add(mesRepViewModel);
            }

            return View(mr);
        }

        // GET: Replies/Details/5
        public ActionResult Details(int? id)
        {
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
        }

        // GET: Replies/Create
        public ActionResult Create(int? id)
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

            return View();
        }

        // POST: Replies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReplyMessage,ReplyFrom,PostingTime,MessageId")] Reply reply, int? id)
        {
            var UManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser appuser = UManager.FindById(User.Identity.GetUserId());
            string test = User.Identity.GetUserId();
            reply.UserId = appuser.Id;
            reply.ReplyFrom = appuser.Email;
            
            reply.PostingTime = DateTime.Now;
            Message m = db.Messages.Find(id);
            reply.MessageId = m.Id;
            db.Replies.Add(reply);
            db.SaveChanges();
            return RedirectToAction("Index", "Categories");

        }
            // GET: Replies/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "Title", reply.MessageId);
            return View(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReplyMessage,ReplyFrom,PostingTime,MessageId")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "Title", reply.MessageId);
            return View(reply);
        }

        // GET: Replies/Delete/5
        public ActionResult Delete(int? id)
        {
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
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reply reply = db.Replies.Find(id);
            db.Replies.Remove(reply);
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
