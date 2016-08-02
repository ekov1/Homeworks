namespace School.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void School_GettingListOfStudents_ShouldReturnTheListOfStudents()
        {
            var school = new School();

            school.Students.Add(new Student("Misho", 55404));

            Assert.AreEqual(1, school.Students.Count);
        }
    }
}
