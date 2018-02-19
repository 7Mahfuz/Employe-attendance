using Employee_attendance_Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Employee_attendance_Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ApplicationDbContext context;

        public AdminController()
        {
            context = new ApplicationDbContext();
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        EmployeeAttendanceContext _context=new EmployeeAttendanceContext();
        // GET: Admin
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
            return View(_context.Employee.ToList());
        }

        public ActionResult Register()
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
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Boom"))
                                               .ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Employee model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                      
                    await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                    //................
                    if (model.UserRoles == "Employee")
                    {
                        _context.Employee.Add(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Admin");
                    }
                    //Ends Here 
                    return RedirectToAction("Index");
                }
                ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Boom"))
                                          .ToList(), "Name", "Name");

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
                //AddErrors(result);
            }
            return View();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
    }
}