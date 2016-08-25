namespace School.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void Course_AddStudent_ShouldAddCorrectly()
        {
            var course = new Course();
            var student = new Student("John", 12120);

            course.AddStudent(student);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_AddStudentTwice_ShouldThrowError()
        {
            var course = new Course();
            var student = new Student("Pesho", 55000);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void Course_RemoveStudent_ShouldRemoveCorrectly()
        {
            var course = new Course();
            var firstStudent = new Student("John", 12120);
            var secondStudent = new Student("Pirat", 12999);

            course.AddStudent(firstStudent);
            course.AddStudent(secondStudent);
            course.RemoveStudent(firstStudent);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_RemoveStudentThatIsNotInCourse_ShouldThrowError()
        {
            var course = new Course();
            var student = new Student("John", 12120);

            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_AddMoreThan30Students_ShouldThrowException()
        {
            var course = new Course();

            for (int i = 0; i < 100; i++)
            {
                course.AddStudent(new Student("Georgi", 10001 + i));
            }
        }
    }
}
