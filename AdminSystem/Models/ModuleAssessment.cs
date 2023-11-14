using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class ModuleAssessment
	{
        [Key]
        public int Id { get; set; }

        public int AssessmentId { get; set; }

        public int ModuleId { get; set; }
    }
}

