using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYPSystem.Models;
using FYPSystem.Data;

namespace FYPSystem.Controllers.Supervisor
{
    public class SupervisorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupervisorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Supervisors
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            string email = HttpContext.User.Identity.Name;
            //string SessionId = HttpContext.Session.Id; This is the way to fetch current logged in user id


            ViewBag.user = await _context.supervisor.Include(x => x.AppUsers).Where(x => x.AppUsers.Email == email).FirstOrDefaultAsync();

            return View();

            //string id = HttpContext.User.Identity.Name;


            //var user = await _context.Students.Where(x => x.AppUsers.Email == id).FirstOrDefaultAsync();

            //return View(user);

        }
    }
}
