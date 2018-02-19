using Employee_attendance_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_attendance_Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        EmployeeAttendanceContext _context = new EmployeeAttendanceContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            if (User.Identity.IsAuthenticated)
            {
                string Namee = User.Identity.Name;
                int chk = _context.Employee.Count(x => x.Username == Namee);

                if (chk == 0)
                {
                    ViewBag.Who = "Admin";
                }
                else { ViewBag.Who = "Employee"; }

            }
            string Name = User.Identity.Name;
            var model = _context.Attendance.Where(x => x.Username == Name).ToList();

            return View(model);
        }

        public ActionResult Detail()
        {
            if (User.Identity.IsAuthenticated)
            {
                string Namee = User.Identity.Name;
                int chk = _context.Employee.Count(x => x.Username == Namee);

                if (chk == 0)
                {
                    ViewBag.Who = "Admin";
                }
                else { ViewBag.Who = "Employee"; }

            }
            string Name = User.Identity.Name;

            Employee employee = _context.Employee.FirstOrDefault(x => x.Username == Name);

            return View(employee);
        }

    }
}