namespace _03.AnimalHierarchy.Units
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Cat : Animal
    {
        public Cat(int age, string name, GenderType gender) : base(age, name, gender)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww!");
        }
    }
}
