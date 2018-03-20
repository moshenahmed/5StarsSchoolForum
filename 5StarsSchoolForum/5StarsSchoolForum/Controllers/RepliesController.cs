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
    public class RepliesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Replies
        public ActionResult Index(int id)
        {

            var model3 = db.Messages.FirstOrDefault(x => x.Id == id).CategoryId;
            
            return RedirectToAction("Details","Categories", new {id = model3 });
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
            var model = new MessageRepliesViewModel();
            
            model.mes = db.Messages.Where(m => m.Id == id).ToList();
            model.rep = db.Replies.Where(g => g.MessageId == id).ToList();
            return View("MessageRepliesViewModel", model);
            
        }

        // POST: Replies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,MessageId,ReplyMessage,PostingTime")]int id, string reply)
        {
            
            if (ModelState.IsValid && reply!="")
            {


                var r = new Reply();
                r.MessageId = id;
                r.PostingTime = DateTime.Now;
                r.ReplyMessage = reply;
                r.User = User.Identity.Name;
                db.Replies.Add(r);
                db.SaveChanges();


                return RedirectToAction("Create", new { id = Url.RequestContext.RouteData.Values["id"] });


            }
            var model2 = new MessageRepliesViewModel();

            model2.mes = db.Messages.Where(m => m.Id == id).ToList();
            model2.rep = db.Replies.Where(g => g.MessageId == id).ToList();
            return View("MessageRepliesViewModel", model2);


            
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
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "PostMessage", reply.MessageId);
            return View(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Users,MessageId,ReplyMessage,PostingTime")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reply).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageId = new SelectList(db.Messages, "Id", "PostMessage", reply.MessageId);
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
            return RedirectToAction("Create", new { id = Url.RequestContext.RouteData.Values["id"] });
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
