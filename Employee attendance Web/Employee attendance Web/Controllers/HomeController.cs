using Employee_attendance_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_attendance_Web.Controllers
{
     
    public class HomeController : Controller
    {
        EmployeeAttendanceContext _context = new EmployeeAttendanceContext();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string Name = User.Identity.Name;
                int chk = _context.Employee.Count(x => x.Username == Name);

                if (chk == 0)
                {
                    ViewBag.Who = "Admin";
                }
                else { ViewBag.Who = "Employee"; }

            }
            return View();
        }

        public ActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                string Name = User.Identity.Name;
                int chk = _context.Employee.Count(x => x.Username == Name);

                if (chk == 0)
                {
                    ViewBag.Who = "Admin";
                }
                else { ViewBag.Who = "Employee"; }

            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                string Name = User.Identity.Name;
                int chk = _context.Employee.Count(x => x.Username == Name);

                if (chk == 0)
                {
                    ViewBag.Who = "Admin";
                }
                else { ViewBag.Who = "Employee"; }

            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}