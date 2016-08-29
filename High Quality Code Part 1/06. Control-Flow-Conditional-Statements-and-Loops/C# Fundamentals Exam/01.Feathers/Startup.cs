namespace _01.Feathers
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            const long MultiplicationMagicNumber = 123123123123;
            const int DivisionMagicNumber = 317;

            double totalBirds = double.Parse(Console.ReadLine());
            double totalFeatherCount = double.Parse(Console.ReadLine());

            if (totalBirds == 0 || totalFeatherCount == 0)
            {
                Console.WriteLine("0.0000");
                return;
            }

            double averageFeathersCount = totalFeatherCount / totalBirds;
            double result = 0;

            if (totalBirds % 2 == 0)
            {
                result = averageFeathersCount * MultiplicationMagicNumber;
            }
            else
            {
                result = averageFeathersCount / DivisionMagicNumber;
            }

            Console.WriteLine("{0:F4}", result);
        }
    }
}
