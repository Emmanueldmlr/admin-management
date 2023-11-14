using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class Student
	{
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdentificationNumber { get; set; }

        public int CohortId { get; set; }

    }
}

