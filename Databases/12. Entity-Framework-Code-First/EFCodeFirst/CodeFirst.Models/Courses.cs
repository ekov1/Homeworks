using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Courses
    {
        private IList<string> materials;

        public Courses()
        {
            this.Materials = new List<string>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public IList<string> Materials
        {
            get
            {
                return this.Materials;
            }

            private set
            {
                this.materials = value;
            }
        }

        public ICollection<Students> Students { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
