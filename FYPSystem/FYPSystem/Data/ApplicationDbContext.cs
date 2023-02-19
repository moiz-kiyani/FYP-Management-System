using FYPSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace FYPSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Supervisor> supervisor { get; set; }

        public DbSet<FYPSystem.Models.Ideas> Ideas { get; set; }

        public DbSet<FYPSystem.Models.Request> Request { get; set; }

        public DbSet<FYPSystem.Models.Evaluation> Evaluation { get; set; }

        public DbSet<FYPSystem.Models.StudentRequestForSupervisorIdeas> StudentRequestForSupervisorIdeas { get; set; }

        public DbSet<FYPSystem.Models.StudentIdeas> StudentIdeas { get; set; }
    }
}
