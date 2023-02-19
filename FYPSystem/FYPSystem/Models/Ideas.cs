using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FYPSystem.Models
{
    public class Ideas
        {
            [Key]
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public string? Approved { get; set; }
            [Display(Name = "Assigned Status")]
            public string? AssignedStatus { get; set; }
            [Display(Name = "Supervisor Name")]
            public string? SupervisorName { get; set; }

            [Display(Name = "Supervisor Shift")]
            public string? SupervisorShift { get; set; }

            [Display(Name = "Idea Creation Time")]
            public DateTime CreatedAt { get; set; }

            public Supervisor supervisor { get; set; }

            [ForeignKey("Supervisor")]
            [Display(Name = "Supervisor Id")]
            public int SupervisorId { get; set; }
        }
    }

