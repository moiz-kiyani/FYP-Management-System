using FYPSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace FYPSystem.Models
{
    public class Supervisor
    {
        [Key]
        public int Id { get; set; }
        public string SupervisorName { get; set; }
        public string ContactNo { get; set; }
        public string Qualification { get; set; }
        public string Domain { get; set; }
        public string Shift { get; set; }
        public string SupervisorFacultyType { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUsers { get; set; }
    }
}
