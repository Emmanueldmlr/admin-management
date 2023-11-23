using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class ModuleGrade
	{
        [Key]
        public int Id { get; set; }

        public double StudentScore { get; set; }

        public int moduleId { get; set; }

        public int StudentId { get; set; }

        public int ProgramId { get; set; }

        public string Grade { get; set; }
    }
}

