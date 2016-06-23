namespace _03.AnimalHierarchy.Units
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tomcat : Cat
    {
        public Tomcat(int age, string name) : base(age, name, GenderType.Male)
        {
           
        }

        public override void MakeSound()
        {
            Console.WriteLine("Mrrrrr...hisssss!");
        }
    }
}
