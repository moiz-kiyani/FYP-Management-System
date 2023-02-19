using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FYPSystem.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderRollNo { get; set; }
        public string SenderContact { get; set; }
        public int RecieverId { get; set; }
        public string RecieverName { get; set; }
        public string RecieverRollNo { get; set; }
        public string RecieverContact { get; set; }
        public string Status { get; set; }

        public Student Student { get; set; }

        [ForeignKey("Student")]

        public int StudentId { get; set; }
    }
}
