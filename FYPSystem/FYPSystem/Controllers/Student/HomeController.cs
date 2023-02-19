using FYPSystem.Data;
using FYPSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FYPSystem.Controllers.Student
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            string email = HttpContext.User.Identity.Name;
            //string SessionId = HttpContext.Session.Id; This is the way to fetch current logged in user id


            ViewBag.user = await _context.Student.Include(x => x.AppUsers).Where(x => x.AppUsers.Email == email).FirstOrDefaultAsync();

            return View();

            //string id = HttpContext.User.Identity.Name;


            //var user = await _context.Students.Where(x => x.AppUsers.Email == id).FirstOrDefaultAsync();

            //return View(user);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}