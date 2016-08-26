namespace Human
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var magicNumber = int.Parse(Console.ReadLine());
            var human = Human.GenerateRandomHuman(magicNumber);

            Console.WriteLine($"Hello, I am {human.Name}, I am a {human.Age} years old and am a {human.Gender}!");
        }
    }
}