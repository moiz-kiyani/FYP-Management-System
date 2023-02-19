using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FYPSystem.Models
{
    public class StudentRequestForSupervisorIdeas
    {
        [Key]
        public int Id { get; set; }
        public int SenderStudentId { get; set; }

        [Display(Name = "Student Name")]
        public string SenderStudentName { get; set; }

        [Display(Name = "Student Roll No")]

        public string SenderStudentRollNum { get; set; }

        [Display(Name = "Student Contact")]

        public string SenderStudentContact { get; set; }

        [Display(Name = "Student Section")]

        //public string SenderStudentSection { get; set; }
        public int ReceiverSupervisorId { get; set; }

        [Display(Name = "Supervisor Name")]

        public string ReceiverSupervisorName { get; set; }

        [Display(Name = "Supervisor Contact")]

        public string ReceiverSupervisorContact { get; set; }

        [Display(Name = "Title of Idea")]
        public string IdeaTitle { get; set; }

        [Display(Name = "Request Status")]
        public string Status { get; set; }

        [Display(Name = "Idea has been Assigned to")]
        public string AssignedTo { get; set; }
    }
}
