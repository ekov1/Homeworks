namespace Methods.Utils
{
    using System;
    using Contracts;
    using Models;

    public class StudentOperations
    {
        public static IStudent GetOlderStudent(Student firstStudent, Student secondStudent)
        {
            DateTime firstDate = DateTime.Parse(firstStudent.BirthdayDate);
            DateTime secondDate = DateTime.Parse(secondStudent.BirthdayDate);

            var olderStudent = firstDate < secondDate ? firstStudent : secondStudent;

            return olderStudent;
        }
    }
}
