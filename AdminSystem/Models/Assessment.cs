using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }

        public int MaximumGrade { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int Code { get; set; }
    }


}

