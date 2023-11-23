﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class Grade
	{
        [Key]
        public int Id { get; set; }

        public double Score { get; set; }

        public string Result { get; set; }

        public int StudentId { get; set; }

        public int ProgramId { get; set; }
    }
}

