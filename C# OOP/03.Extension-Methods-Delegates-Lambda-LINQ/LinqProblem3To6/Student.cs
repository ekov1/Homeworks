namespace LinqProblems
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        
        public Student(string firstName, string lastName, int age, string fn, string tel, string email
            , List<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }
        public int Age { get; set; }

        public static Student[] StudentsInfo()
        {
            var result = new Student[5];
            result[0] = new Student("Pesho", "Ivanov", 20, "10230667", "+359 2 937 2211", "PeshoMail@abv.bg", new List<int> { 6, 5, 2, 6, 2, 4 }, 2);
            result[1] = new Student("George", "Petkov", 12, "10230557", "+359 2 937 2212", "GoshoMail@mail.bg", new List<int> { 3, 5, 3, 6, 5, 4 }, 3);
            result[2] = new Student("Ivan", "Georgiev", 30, "19234127", "+359 2 937 2213", "IvanMail@abv.bg", new List<int> { 3, 5, 5, 6, 3, 4 }, 2);
            result[3] = new Student("Stefan", "Varbanov", 14, "10234817", "+359 32 656 700", "Stefan2@gmail.com", new List<int> { 2, 5, 2, 6, 2, 4 }, 4);
            result[4] = new Student("Stefan", "Kostov", 23, "10230617", "+359 32 656 703", "StefanMail@yahoo.com", new List<int> { 3, 5, 2, 3, 2, 4 }, 1);
            return result;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public static void Print(Student[] studentList)
        {
            foreach (var item in studentList)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
