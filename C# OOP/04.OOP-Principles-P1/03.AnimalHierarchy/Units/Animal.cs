namespace _03.AnimalHierarchy.Units
{
    using Enums;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private GenderType gender;

        public Animal(int age, string name, GenderType gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Age cannot be negative or over 100!");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Name cannot be left empty!");
                }
                this.name = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }


        public virtual void MakeSound()
        {
            Console.WriteLine("I am making animal sounds..");
        }
    }
}
