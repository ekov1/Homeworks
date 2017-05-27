namespace CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst.Data.SchoolDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirst.Data.SchoolDbContext context)
        {
            //var course = new Courses() { Name = "Maths", Description = "We are the best!" };
            //var homework = new Homework() { Content = "1 + 1 = 3", TimeSent = DateTime.Now };

            //context.Students.AddOrUpdate(new Students()
            //{
            //    Name = "John Doe",
            //    StudentNumber = "40530212",
            //    Courses = new List<Courses>() { course },
            //    Homeworks = new List<Homework>() { homework }
            //});
        }
    }
}
