namespace _02.Busses
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int numberOfBusses = int.Parse(Console.ReadLine());
            int[] bussSpeeds = new int[numberOfBusses];
            int groupsCount = 1;

            InitializeBussSpeeds(bussSpeeds, numberOfBusses);

            int currentBusSpeed = bussSpeeds[0];
            for (int i = 1; i < numberOfBusses; i++)
            {
                var formsGroup = currentBusSpeed > bussSpeeds[i] || currentBusSpeed == bussSpeeds[i];

                if (formsGroup)
                {
                    currentBusSpeed = bussSpeeds[i];
                    groupsCount++;
                }
            }
            Console.WriteLine(groupsCount);
        }

        private static void InitializeBussSpeeds(int[] bussSpeeds, int numberOfBusses)
        {
            for (int i = 0; i < numberOfBusses; i++)
            {
                bussSpeeds[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
