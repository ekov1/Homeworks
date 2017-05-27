using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Students
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string StudentNumber { get; set; }

        public int Age { get; set; }

        public ICollection<Courses> Courses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
