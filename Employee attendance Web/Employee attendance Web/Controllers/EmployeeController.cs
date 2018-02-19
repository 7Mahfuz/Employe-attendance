using Employee_attendance_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_attendance_Web.Controllers
{
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
            string Name = User.Identity.Name;
            var model = _context.Attendance.Where(x => x.Username == Name).ToList();

            return View(model);
        }


    }
}