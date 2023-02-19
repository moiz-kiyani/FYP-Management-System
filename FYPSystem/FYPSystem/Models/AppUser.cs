using FYPSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace FYPSystem.Models
{
    public class AppUser : IdentityUser
    {
        public string Roles { get; set; }

        public ICollection<Student> Student { get; set; }
        public ICollection<Supervisor> supervisor { get; set; }
    }
}
