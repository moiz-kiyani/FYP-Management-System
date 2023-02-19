using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FYPSystem.Models
{
    public class StudentSendRequestToSupervisor
    {

        [Key]
        public int Id { get; set; }
        public int SenderStudentId { get; set; }
        [Display(Name = "Student Name")]
        public string SenderStudentName { get; set; }
        [Display(Name = "Student Roll Number")]
        public string SenderStudentRollNo { get; set; }
        [Display(Name = "Student Contact")]
        public string SenderStudentContact { get; set; }
        public int RecieverSupervisorId { get; set; }
        [Display(Name = "Supervisor Name")]
        public string RecieverSupervisorName { get; set; }

        [Display(Name = "Supervisor Email")]
        public string RecieverSupervisorEmail { get; set; }
        public string Status { get; set; }
    }
}
