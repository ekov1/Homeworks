using CodeFirst.Data;
using CodeFirst.Models;
using System;
using System.Linq;

namespace CodeFirst.App
{
    public class Startup
    {
        public static void Main()
        {
            var context = new SchoolDbContext();

            var student = GetStudentByName(context, "John");

            Console.WriteLine("Student name: {0} / Student number: {1}", student.Name, student.StudentNumber);
        }

        private static Students GetStudentByName(SchoolDbContext context, string studentName)
        {
            using (context)
            {
                var student = context.Students.Where(x => x.Name.Contains(studentName)).FirstOrDefault();
                return student;
            }
        }
    }
}
