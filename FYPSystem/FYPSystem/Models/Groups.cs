using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FYPSystem.Models
{
    public class Groups
    {
        [Key]
        public int Id { get; set; }
        public string GroupIds { get; set; }
        public string GroupNames { get; set; }
        public string GroupRollNumbers { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        public int LeaderId { get; set; }

        [Display(Name = "Leader Name")]
        public string LeaderName { get; set; }
        public int SupervisorId { get; set; }

        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }

        [Display(Name = "Supervisor Email")]
        public string SupervisorEmail { get; set; }
    }
}
