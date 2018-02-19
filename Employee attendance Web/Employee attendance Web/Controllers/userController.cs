using Employee_attendance_Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_attendance_Web.Controllers
{
    [Authorize]
    public class usersController : Controller
    {

        public int isAdminUser()
        {
            int mark = 0;
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());

                if (s[0].ToString() == "Admin")
                {
                    mark = 1;
                }
                else if (s[0].ToString() == "Employee")
                {
                    mark = 2;
                }
                

            }
            return mark;
        }


        // GET: Users
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                int mark = 0;
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";
                mark = isAdminUser();
                if (mark == 1)
                {
                    //ViewBag.displayMenu = "Yes";
                    return RedirectToAction("Index", "Home");
                }
                if (mark == 2)
                {
                    //ViewBag.displayMenu = "Yes";
                    return RedirectToAction("Detail", "Employee");
                }
                
                //return View();
            }
            else
            {
                return RedirectToAction("Contact", "Home");
                //ViewBag.Name = "Not Logged IN";
            }

            return View();

        }

    }
}
