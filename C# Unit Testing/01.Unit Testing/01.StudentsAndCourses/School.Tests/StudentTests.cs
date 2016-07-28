namespace School.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_SettingEmptyName_ShouldThrowError()
        {
            var student = new Student("", 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_SettingWhiteSpaceName_ShouldThrowError()
        {
            var student = new Student(" ", 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_SettingIDGreaterThanMaxValueForID_ShouldThrowError()
        {
            var student = new Student("John", 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_SettingIDLowerThanMinValueForID_ShouldThrowError()
        {
            var student = new Student("John", 10000);
        }

        [TestMethod]
        public void Student_JoinCourse_ShouldProperlyJoinCourse()
        {
            var student = new Student("John", 10100);
            var course = new Course();

            student.JoinCourse(course);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void Student_LeaveCourse_ShouldProperlyJoinCourse()
        {
            var firstStudent = new Student("Michael", 99000);
            var secondStudent = new Student("John", 10100);
            var course = new Course();

            firstStudent.JoinCourse(course);
            secondStudent.JoinCourse(course);

            firstStudent.LeaveCourse(course);

            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void Student_GetName_ShouldProperlyGetStudentName()
        {
            var student = new Student("John", 10100);
            var name = student.Name;

            Assert.AreEqual("John" , name);
        }

        [TestMethod]
        public void Student_GetID_ShouldProperlyGetStudentID()
        {
            var student = new Student("John", 10100);
            var id = student.ID;

            Assert.AreEqual(10100, id);
        }

    }
}
