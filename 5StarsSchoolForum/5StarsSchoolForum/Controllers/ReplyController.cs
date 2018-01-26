using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _5StarsSchoolForum.Models;

namespace _5StarsSchoolForum.Controllers
{
    public class ReplyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reply
        public ActionResult Index()
        {
            var replies = db.Replies.Include(r => r.Message);
            return View(replies.ToList());
        }

        // GET: Reply/Details/5
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

        // GET: Reply/Create
        public ActionResult Create()
        {
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "Title");
            return View();
        }

        // POST: Reply/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MessageId,PostingTime,ReplyMessage")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                reply.PostingTime = DateTime.Now;
                db.Replies.Add(reply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageId = new SelectList(db.Messages, "Id", "Title", reply.MessageId);
            return View(reply);
        }

        // GET: Reply/Edit/5
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

        // POST: Reply/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MessageId,PostingTime,ReplyMessage")] Reply reply)
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

        // GET: Reply/Delete/5
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

        //POST: Reply/Delete/5
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
