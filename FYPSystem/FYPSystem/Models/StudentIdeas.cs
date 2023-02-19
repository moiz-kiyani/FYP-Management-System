using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FYPSystem.Models
{
    public class StudentIdeas
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        
        public string? StudentName { get; set; }

        [Display(Name = "Student RollNo")]
        public string? StudentRollNo { get; set; }

        public Student Student { get; set; }

        [ForeignKey("Student")]
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }
    }
}
