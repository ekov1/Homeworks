namespace _03.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Units;

    public class AnimalCalculations
    {
        public static void AvgAge<T>(List<T> animals) where T : Animal
        {
            Console.Write($"Average age of {animals[0].GetType().Name}s is: -> ");

            var avgAge = animals
                .Select(x => x.Age)
                .ToList()
                .Average();

            Console.WriteLine(avgAge + " years");
            Console.WriteLine();
        }
    }
}
