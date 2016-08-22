namespace LinqProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SortingStudents
    {   

        public static void GroupNumberSort(this IEnumerable<Student> students)
        {
            var sortedStudents = students
                .OrderBy(x => x.GroupNumber)
                .ToArray();

            foreach (var item in sortedStudents)
            {
                Console.WriteLine("Group number: {0} - Student: {1} {2}", item.GroupNumber, item.FirstName, item.LastName);
            }
        }
        public static void PrintData(this IEnumerable<Student> data)
        {
            foreach (var item in data)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
        public static void SortNumbers(IEnumerable<int> numbers)
        {
            //Lambda:
            var sortedNumbers = numbers
                .Where(x => (x % 3 == 0) && (x % 7 == 0))
                .ToList();
            ////Linq:
            //    var sortedNumbers = from number in numbers
            //                        select (decimal)number
            //                        where (number % 3 == 0) && (number % 7 == 0)
            //                        select number;

            var result = string.Join(" ", sortedNumbers);
            Console.WriteLine(result);
        }

        public static Student[] GroupStudents(this Student[] students)
        {
            var groupStudents = students
                .Where(x => x.GroupNumber == 2)
                .ToArray();

            return groupStudents;

        }
        public static Student[] LastNameBiggerThanFirstName(Student[] students)
        {
            var result = students
                .Where(x => (x.FirstName).CompareTo(x.LastName) < 0)
                .ToArray();

            return result;
        }

        public static Student[] AgeRange(Student[] students)
        {
            var result = students
                .Where(x => (x.Age > 18) && x.Age < 24)
                .ToArray();

            return result;
        }

        public static Student[] SortByFirstAndLastName(Student[] students)
        {
            var result = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .ToArray();

            return result;
        }

        public static void GroupByGroupNumber(Student[] students)
        {
            var grByGrNumber = from student in students
                               where student.GroupNumber == 2
                               select student;

            grByGrNumber.PrintData();
        }

        public static void GroupByEmail(Student[] students)
        {
            var groupedByEmail = students
        .Where(x => x.Email.Contains("abv.bg"))
        .ToArray();

            groupedByEmail.PrintData();
        }

        public static void StudentsWithPhones(Student[] students)
        {
            var groupHavePhone = students
         .Where(x => !x.Tel.Contains("+359 2"))
         .ToArray();
            groupHavePhone.PrintData();
        }

        public static void MarksFrom2006(Student[] students)
        {
            var marksFrom2006 = students
                .Where(x => (x.FN[4] == '0') && (x.FN[5] == '6'))
                .ToArray();

            foreach (var item in marksFrom2006)
            {
                Console.WriteLine("Marks: -> {0}", string.Join(" ", item.Marks));
            }
        }

        public static void MathStudents(Student[] students)
        {
            var mathDepartament = from student in students
                                  join gr in Group.Groups on student.GroupNumber equals gr.GroupNumber
                                  where student.GroupNumber == 1
                                  select new { GroupName = gr.DepartmentName, student.FirstName, student.LastName };


            foreach (var item in mathDepartament)
            {
                Console.WriteLine(item);
            }
        }

        public static void LongestString(string[] array)
        {
            var longestSting = array
                .OrderByDescending(x => x.Length)
                .First();

            Console.WriteLine("Longest string from array -> {0}", longestSting);
        }

        public static void SortStudentsByGroupNumber(Student[] students)
        {
            var sortedStudents = students
                .OrderBy(x => x.GroupNumber)
                .ToArray();

            foreach (var item in sortedStudents)
            {
                Console.WriteLine("Group number: {0} - Student: {1} {2}", item.GroupNumber, item.FirstName, item.LastName);
            }
        }
    }
}
