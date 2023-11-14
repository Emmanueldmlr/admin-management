using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class ProgrammeModule
	{
        [Key]
        public int Id { get; set; }

        public int ModuleId { get; set; }

        public int ProgrammeId { get; set; }

        public Boolean IsOptional { get; set; }
    }

}

