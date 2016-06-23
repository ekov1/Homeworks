namespace _02.StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Units;
    class Startup
    {
        static void Main()
        {
            var students = DataGenerator.GenerateStudents();
            var workers = DataGenerator.GenerateWorkers();

            //SortWorkersAndStudents.SortStudentsByGrade(students);

            //SortWorkersAndStudents.SortWorkersByMoney(workers);

            //SortWorkersAndStudents.SortAllByFirstAndLastName(students, workers);
        }
    }
}
