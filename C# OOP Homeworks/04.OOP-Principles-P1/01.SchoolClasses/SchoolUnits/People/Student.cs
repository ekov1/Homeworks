namespace _01.SchoolClasses.SchoolUnits.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student : Human
    {
        private int uClassNumber;

        public Student(string name, int classNumber) : base(name)
        {
            this.UniqueClassNumber = classNumber;
        }

        public int UniqueClassNumber
        {
            get
            {
                return this.uClassNumber;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Class number cannot be a negative number!");
                }
                this.uClassNumber = value;
            }
        }
    }
}
