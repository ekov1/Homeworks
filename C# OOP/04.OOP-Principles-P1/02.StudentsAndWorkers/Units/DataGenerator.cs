namespace _02.StudentsAndWorkers.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DataGenerator
    {
        private static Random gen = new Random();

        private static List<string> firstNames = new List<string>()
            {
                "Pesho", "Gosho", "Ivan", "Mitko", "Kiril", "Mango", "Konstantin", "Mimo", "Michael",
                 "Josh"
            };

        private static List<string> lastNames = new List<string>()
            {
                "Mitkov", "Toshov", "Ivanov", "Georgiev", "Metoviev", "Kirilov", "Chilarov", "Kotkov", "Chichkov",
                 "Mitrev"
            };

        public static List<Student> GenerateStudents()
        {
            List<Student> students = new List<Student>
            {
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
                new Student(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(1, 13)),
            };

            return students;
        }
        
        public static List<Worker> GenerateWorkers()
        {
            List<Worker> workers = new List<Worker>()
            {
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25)),
                new Worker(firstNames[gen.Next(firstNames.Count)], lastNames[gen.Next(lastNames.Count)], gen.Next(100, 100000), gen.Next(1, 25))
            };
            return workers;
        }
    }

}
