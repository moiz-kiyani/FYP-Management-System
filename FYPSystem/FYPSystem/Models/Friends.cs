using System.ComponentModel.DataAnnotations;

namespace FYPSystem.Models
{
    public class Friends
    {
        [Key]
        public int Id { get; set; }
        public string StudentId { get; set; }

        public string StudentId2 { get; set; }
    }
}
