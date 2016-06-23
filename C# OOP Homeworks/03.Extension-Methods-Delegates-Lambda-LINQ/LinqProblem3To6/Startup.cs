namespace LinqProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()  //Uncomment to test :)
        {
            var students = Student.StudentsInfo();

            //Problem 3. First before last
            //var sortedByLastName = SortingStudents.LastNameBiggerThanFirstName(students);
            //Student.Print(sortedByLastName);
            //--------------------------------------------------------------------------------------------------------
            //Problem 4. Age range
            //var sortedByAge = SortingStudents.AgeRange(students);
            //Student.Print(sortedByAge);
            //--------------------------------------------------------------------------------------------------------

            //Problem 5. Order students
            //var sortedByBothNames = SortingStudents.SortByFirstAndLastName(students);
            //Student.Print(sortedByBothNames);
            //--------------------------------------------------------------------------------------------------------

            //Problem 6. Divisible by 7 and 3
            var numbers = Enumerable.Range(3, 100);
            //SortingStudents.SortNumbers(numbers);
            //--------------------------------------------------------------------------------------------------------

            //Problem 9. Student groups
            //SortingStudents.GroupByGroupNumber(students);
            //--------------------------------------------------------------------------------------------------------

            //Problem 10. Student groups extensions
            //var result = students.GroupStudents();
            //result.PrintData();
            //--------------------------------------------------------------------------------------------------------

            //Problem 11. Extract students by email
            //SortingStudents.GroupByEmail(students);
            //--------------------------------------------------------------------------------------------------------

            //Problem 12. Extract students by phone // Assuming "with phone" means have a GSM not home phone
            //SortingStudents.StudentsWithPhones(students);
            //--------------------------------------------------------------------------------------------------------

            //Problem 13. Extract students by marks
            var anonArray = new[]
            {
                new { FullName = "Georgi Kokov", Marks = new List<int> { 2, 4, 5, 4, 2} },
                new { FullName = "Shoko Mokov", Marks = new List<int> { 2, 2, 4, 3, 6} },
                new { FullName = "Zaio Baio", Marks = new List<int> { 5, 6, 5, 4, 3} },
                new { FullName = "Mimo Pitona", Marks = new List<int> { 4, 5, 4, 6, 6} }
            };

            //var studentsWith6 = anonArray
            //    .Where(x => x.Marks.Contains(6))
            //    .ToArray();

            //foreach (var item in studentsWith6)
            //{
            //    Console.WriteLine($"{item.FullName} -> Marks: {string.Join(" ", item.Marks)}");
            //}
            //--------------------------------------------------------------------------------------------------------

            //Problem 14. Extract students with two marks
            //var studentsWith2 = anonArray
            //   .Where(x => x.Marks
            //       .Where(m => m == 2)
            //       .Count() == 2)
            //   .ToArray();
            //foreach (var item in studentsWith2)
            //{
            //    Console.WriteLine($"{item.FullName} -> Marks: {string.Join(" ", item.Marks)}");
            //}
            //--------------------------------------------------------------------------------------------------------

            //Problem 15. Extract marks
            //SortingStudents.MarksFrom2006(students);
            //--------------------------------------------------------------------------------------------------------
            //Problem 16.* Groups
            //SortingStudents.MathStudents(students);
            //--------------------------------------------------------------------------------------------------------

            //Problem 17. Longest string
            //var stringArray = new string[] { "alabala", "blalvala", "thisisprobablythelongeststring", "else" };
            //SortingStudents.LongestString(stringArray);

            //Problem 18. Grouped by GroupNumber
            //SortingStudents.SortStudentsByGroupNumber(students);

            //--------------------------------------------------------------------------------------------------------
            //Problem 19. Grouped by GroupName extensions
            //students.GroupNumberSort();
        }
    }
}