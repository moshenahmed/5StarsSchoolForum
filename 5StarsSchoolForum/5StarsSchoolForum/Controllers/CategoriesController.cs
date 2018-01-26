using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using _5StarsSchoolForum.Models;

namespace _5StarsSchoolForum.Controllers
{
    public class CategoriesController : Controller
    {
    private ApplicationDbContext db = new ApplicationDbContext();
        /*  private readonly ApplicationDbContext _context; 

      public CategoriesController()
        {
        _context=new ApplicationDbContext();
        }

          [Authorize]
          public ActionResult Create()
      {
          var viewModel = new CategoryFormViewModel
          {
             Classes=_context.Classes.ToList();
          }
          return View(viewModel);
      }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CategoryFormViewModel viewModel)
        {
        var studentId=UserIdentity.GetUserId()
        var student= _context.User.Single(u=>u.Id==studentId);
        var genre= _context.Class.Single(g=>g.Id==viewModel.Class);
        var category=new Category
         {
         Student=student,
         DateTime=DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time))
         Class=class,
         Name=viewModel.Name
         }; 
          _context.Categories.Add(category);
           _context.SaveChanges();

         return RedirectToAction("Index","Home");
      }
     */



        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult CategoryList()
        {
            var model = db.Categories.ToList();
            return View("SelectCategories",model);
        }


        //// GET: Categories/Details/5
        //public ActionResult Studentlist()
        //{
        //    var model = db.Users.Where(n => n.Role == "Student");
        //    return View("Studentlist", model);
        //}
        //public ActionResult Teacherlist()

        //{
        //    var model = db.Users.Where(n => n.Role == "Teacher");
        //    return View("Studentlist", model);
        //}



        // GET: Categories/Details/5
        public ActionResult Studentlist()

        {
            var model = db.Users.Where(n => n.Role=="Student");
            return View("Studentlist", model);
        }
        public ActionResult Teacherlist()

        {
            var model = db.Users.Where(n => n.Role == "Teacher");
            return View("Studentlist", model);
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
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
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
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
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
