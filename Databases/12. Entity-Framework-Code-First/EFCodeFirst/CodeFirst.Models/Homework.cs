using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Homework
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
