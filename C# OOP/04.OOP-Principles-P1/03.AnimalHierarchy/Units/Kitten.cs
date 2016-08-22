namespace _03.AnimalHierarchy.Units
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Kitten : Cat
    {
        public Kitten(int age, string name) : base(age, name, GenderType.Female)
        {
            
        }

        public override void MakeSound()
        {
            Console.WriteLine("Sweet meowww  ^._.^ !");
        }
    }
}
