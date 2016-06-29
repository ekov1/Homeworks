namespace _01.StudentClass.Units.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Enums;
    using Utils;

    public class StudentClassTest
    {
        public static void TestOverriddenMethods()
        {
            Student firstStudent = new Student("Georgi", "Ivanov", "Mitkov", 1234, "bul.Bulgaria 20", "hehe@abv.bg", "0888123456", "IT", Specialties.SoftwareEngineering, Universities.Cambridge, Faculties.ITBackEnd);
            Student secondStudent = new Student("Kircho", "Mirkov", "Ivanov", 5678, "bul.Cherni Vruh 4", "lolo@gmail.com", "0885777666", "Maths", Specialties.Surgeries, Universities.KaspichanUniversity, Faculties.Medicine);

            var equalStudents = firstStudent == secondStudent;
            var hashCode = firstStudent.GetHashCode();

            // Testing Equal()
            Console.WriteLine("\nFirst and second student are equal? -> {0}", equalStudents);
            GlobalConstants.ContentSeparator();

            // Testing GetHashCode()
            Console.WriteLine("Hash code of first student -> " + hashCode);
            GlobalConstants.ContentSeparator();

            // Printing Student
            Console.WriteLine(firstStudent);
            GlobalConstants.ContentSeparator();

            // Changing the specialty on the cloning student doesnt affect the original firstStudent 
            var firstStudentCloning = firstStudent.Clone() as Student;
            firstStudentCloning.Faculty = Faculties.Sports;
            Console.WriteLine(firstStudentCloning);

            // Comparing students by first criteria -> Names, then by second criteria -> SS Number
            GlobalConstants.ContentSeparator();
            Console.WriteLine("Comparisson -> " + firstStudent.CompareTo(secondStudent) + Environment.NewLine);
            GlobalConstants.ContentSeparator();
        }
    }
}
