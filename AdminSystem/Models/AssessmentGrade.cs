using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class AssessmentGrade
	{
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ModuleAssessmentId { get; set; }

        public double Score { get; set; }
    }
}

