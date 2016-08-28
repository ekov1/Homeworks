namespace LoopRefactoring
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        private const int MagicGivenNumber = 100;
        private const int ExitStateValue = 666;

        public static void Main()
        {
            int[] array = Enumerable.Range(1, MagicGivenNumber).ToArray();
            var randomGen = new Random();

            // Didn't figure out what initial expected value stands for so I made it on a random principle
            var index = randomGen.Next(0, array.Length);
            var expectedValue = array[index];

            for (int i = 0; i < MagicGivenNumber; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        i = ExitStateValue;
                    }
                }

                if (i == ExitStateValue)
                {
                    Console.WriteLine("Value found!");
                    break;
                }
            }
        }
    }
}
