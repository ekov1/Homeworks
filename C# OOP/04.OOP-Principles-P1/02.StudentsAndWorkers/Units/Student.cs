namespace _02.StudentsAndWorkers.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value <= 0 || value > 12)
                {
                    throw new ArgumentException("Grade cannot be less than zero or more than 12!");
                }
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return $"Full name: {this.FirstName} {this.LastName} - > Grade: {this.Grade}";
        }
    }
}
