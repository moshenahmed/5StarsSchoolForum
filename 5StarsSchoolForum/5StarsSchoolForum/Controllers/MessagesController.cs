using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _5StarsSchoolForum.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;


namespace _5StarsSchoolForum.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index(int? id)

        {
            //List<MessageReplyView> messagereply = new List<MessageReplyView>();
            
            var model = db.Messages.Where(x=>x.CategoryId==id).ToList();

            
            return PartialView( "IndexPartial", model);
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


            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,PostMessage,PostingDate,user")] int id, Message m )
        {
            m.PostingDate = DateTime.Now;
            m.User = User.Identity.Name;
            m.CategoryId = id;
            
            if (ModelState.IsValid)
            {
                var model = (from cate in db.Categories
                             where cate.Id == id
                             select new Message()
                             {
                                 CategoryId=m.CategoryId,
                                 PostingDate = m.PostingDate,
                                 
                                 PostMessage  =  m.PostMessage,
                                 
                                 User = m.User
                             });
                db.Messages.Add(m);
                db.SaveChanges();
                return RedirectToAction("Details","Categories",new { id = Url.RequestContext.RouteData.Values["id"] });
            }

            return View();
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
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,PostMessage,PostingDate")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
        public ActionResult CreateReply()
        {
            return View();
        }
        [HttpPost]
            public ActionResult CreateReply(MessageReplyViewModel reply, int id)
        {
            var mess = new Message();
            var rep = new Reply();


            var model = db.Messages.Where(v => v.Id==id).Select(f=>f.PostMessage).ToString();

            reply.MessagePosted = model;
            reply.PostingTime = DateTime.Now;
            rep.ReplyMessage = reply.ReplyToMessage;
            rep.PostingTime = reply.PostingTime;
            //reply.MessagePosted = model;
            //rep.MessageId = id;
            //rep.ReplyMessage = reply.ReplyToMessage;
            //reply.PostingTime = DateTime.Now;
            //rep. PostingTime = reply.PostingTime;
            db.Replies.Add(rep);
            db.SaveChanges();



            return View(reply);
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
