using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class Cohort
	{
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        public int ProgrammeId { get; set; }
    }
}

