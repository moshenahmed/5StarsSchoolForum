using _5StarsSchoolForum.Models;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
                             PostMessage = mes.PostMessage,
                             PostingDate = mes.PostingDate,
                             Usertag= mes.User
                         }).ToList();

            return View(model);
        }
        public ActionResult CategoryList()
        {
            var model = db.Categories.ToList();
            return View(model);
        }

        // GET: Categories/Details/5
        public ActionResult Studentlist()

        {
            var model = (from user in db.Users
                         from userRole in user.Roles
                         join role in db.Roles on userRole.RoleId equals
                         role.Id

                         select new UserViewModel()
                         {
                             User = user,

                             Roles = role
                         }).Where(x => x.Roles.Name == "Student").ToList();

            return View("Studentlist", model);
        }
        public ActionResult Teacherlist()
        {
            var model = (from user in db.Users
                         from userRole in user.Roles
                         join role in db.Roles on userRole.RoleId equals
                         role.Id
                         select new UserViewModel()
                         {
                             User = user,
                             Roles = role
                         }).ToList();

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

            var model = db.Categories.Where(n => n.Id == id).ToList();
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
        public ActionResult Create([Bind(Include = "Id,CategoryTitle")] Category model)
        {

            if (ModelState.IsValid)
            {
                var category = new Category();

                category.CategoryTitle = model.CategoryTitle;
                
                db.Categories.Add(category);
                db.SaveChanges();

                return RedirectToAction("CategoryList");
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
        public ActionResult Edit([Bind(Include = "Id,CategoryTitle")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CategoryList");
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
            var category = db.Categories.Find(id);
            var messageCount = db.Messages.Count(x => x.CategoryId == id);
            if (messageCount > 0)
            {
                var messages = db.Messages.Where(x => x.CategoryId == id)
                    .Select(v => v.Id).ToList();
                foreach (var messageId in messages)
                {                 
                    var replyCount = db.Replies.Count(x => x.MessageId == messageId);
                    if (replyCount > 0)
                    {
                        var replies = db.Replies.Where(x => x.MessageId == messageId)
                            .Select(v => v.Id).ToList();
                        foreach (var replyId in replies)
                        {
                            db.Replies.Remove(db.Replies.Find(replyId));
                        }
                    }
                    db.Messages.Remove(db.Messages.Find(messageId));
                }
            }

            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult CreateReply(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (id == null)
            {
                return HttpNotFound();
            }
            return View();
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
        
            public ActionResult Assign(int id)
        {
            var model = db.Users.Find(id).Id;
            db.SaveChanges();

            return View(model);
        }

        public ActionResult GetLoggedInUserId()
        {
            var userId = db.Users.First(x  => x.UserName == User.Identity.Name).Id;

            return RedirectToAction("AssignedCategories", "Home", new { id = userId });
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