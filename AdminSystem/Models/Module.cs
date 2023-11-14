using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class Module
	{
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Code { get; set; }
    }
}

