using FYPSystem.Data;
using FYPSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FYPSystem.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ApplicationDbContext _context;

        public LogoutModel(SignInManager<AppUser> signInManager, ILogger<LogoutModel> logger, ApplicationDbContext applicationDb)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = applicationDb; 
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            string email = HttpContext.User.Identity.Name;
            var GetRole = _context.AppUsers.Where(x => x.Email == email).FirstOrDefault();
            string returnUrl = null;


            if (GetRole.Roles == "Student")
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                return RedirectToPage("./StudentLogin");

            }
            else if (GetRole.Roles == "Supervisor")
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                //returnUrl = "~/Supervisor/SupervisorLogin";
                return RedirectToPage("./Supervisor/SupervisorLogin");
            }
            return Page();
        }
    }
}
