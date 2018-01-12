using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5StarsSchoolForum.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                //if ()
                //{
                //    ViewBag.displayMenu = "Yes";
                //}
                //return View();
            }
            else
            {
                ViewBag.Name = "Please log in to Continue!..";
            }
            return View();
        }
    }
    }