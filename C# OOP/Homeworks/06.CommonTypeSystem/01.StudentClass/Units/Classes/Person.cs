namespace _01.StudentClass.Units.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Units.Utils;

   public class Person
    {
        private string name;
        private int? age;

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Verification.NullVerification(value);
                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        // I thought it will look better to make a method printing both people here than in the main contructor
        // Dont judge by lazyness :D
        public static void PrintPeople(Person man, Person woman)
        {
            Console.WriteLine("Man and woman data");
            GlobalConstants.ContentSeparator();
            Console.WriteLine(man);
            GlobalConstants.ContentSeparator();
            Console.WriteLine(woman);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Name: {this.Name}");

            if (this.Age != null)
            {
                builder.AppendLine($"Age: {this.Age}");
            }
            else
            {
                builder.AppendLine($"Age: <not specified>");
            }

            return builder.ToString();
        }
    }
}
