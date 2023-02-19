using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYPSystem.Controllers
{
    public class StartingPageController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
    }
}
