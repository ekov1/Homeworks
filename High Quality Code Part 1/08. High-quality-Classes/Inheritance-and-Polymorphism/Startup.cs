namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using InheritanceAndPolymorphism.Models;

    public class Startup
    {
        public static void Main()
        {
            var students = new List<string>() { "Peter", "Maria", "Thomas", "Ani", "Steve" };

            OffsiteCourseExample(students);

            LocalCourseExample(students);
        }

        private static void OffsiteCourseExample(IList<string> students)
        {
            var offsiteCourseName = "PHP and WordPress Development";
            var offsiteCourseTeacherName = "Mario Peshev";
            var offsiteCourseTown = "Dobrich";

            var offsiteCourse = new OffsiteCourse(offsiteCourseName, offsiteCourseTeacherName, offsiteCourseTown);
            offsiteCourse.AddStudents(students);

            Console.WriteLine(offsiteCourse);
        }

        private static void LocalCourseExample(IList<string> students)
        {
            var localCourseName = "Databases";
            var localCourseTeacherName = "Svetlin Nakov";
            var localCourseLabName = "Enterprise";

            var localCourse = new LocalCourse(localCourseName, localCourseTeacherName, localCourseLabName);
            localCourse.AddStudents(students);

            Console.WriteLine(localCourse);
        }
    }
}
