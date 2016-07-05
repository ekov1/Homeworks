namespace _02.StudentsAndWorkers.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Worker : Human
    {
        private int weekSalary;
        private int workHrsPerDay;

        public Worker(string firstName, string lastName, int weekSalary, int workHrsPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHoursADay = workHrsPerDay;
        }

        public int WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be a negative number!");
                }
                this.weekSalary = value;
            }
        }

        public int WorkingHoursADay
        {
            get
            {
                return this.workHrsPerDay;
            }

            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentException("Working hours cannot be less than zero or more than 24 hours!");
                }
                this.workHrsPerDay = value;
            }
        }

        public double MoneyPerHour()
        {
            double moneyPerHr = (this.WeekSalary / 7) / this.WorkingHoursADay;
            return moneyPerHr;
        }

        public override string ToString()
        {
            return $"Full name: {this.FirstName} {this.LastName} -> Money per hr: {this.MoneyPerHour()}";
        }
    }
}
