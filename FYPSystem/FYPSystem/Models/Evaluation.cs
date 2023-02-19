using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FYPSystem.Models
{
    public class Evaluation
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Roll Number")]
        public string RollNum { get; set; }

        [Display(Name = "Proposal Marks")]
        public float ProposalMarks { get; set; }

        [Display(Name = "Poster Marks")]
        public float PosterMarks { get; set; }

        [Display(Name = "Supervisor Marks")]
        public float SupervisorMarks { get; set; }

        //[Display(Name = "Examiner 1")]
        //public float ExaminerOne { get; set; }

        //[Display(Name = "Examiner 2")]
        //public float ExaminerTwo { get; set; }

        [Display(Name = "Total Marks")]
        public float TotalMarks { get; set; }
        //So that during the Allottment of supervisor to the group that supervisor is assigned to the evaluation table of those students who are present in group
        public int SupervisorId { get; set; }
        public string? SupervisorName { get; set; }
        public string? SupervisorEmail { get; set; }
        //[Required]
        //[Display(Name = "Evaluator 1 Name")]
        //public string EvaluatorOneName { get; set; }
        //[Required]
        //[Display(Name = "Evaluator 2 Name")]
        //public string EvaluatorTwoName { get; set; }

        public Student Student { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
}
