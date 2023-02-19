using System.ComponentModel.DataAnnotations;

namespace FYPSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string ContactNo { get; set; }
        public string RollNo { get; set; }
        public string Semester { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUsers { get; set; }
    }
}
