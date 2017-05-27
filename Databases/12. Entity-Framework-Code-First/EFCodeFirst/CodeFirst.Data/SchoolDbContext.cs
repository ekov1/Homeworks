using CodeFirst.Models;
using System;
using System.Data.Entity;

namespace CodeFirst.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
            : base("SchoolDb")
        {
        }

        public IDbSet<Courses> Courses { get; set; }

        public IDbSet<Students> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}
