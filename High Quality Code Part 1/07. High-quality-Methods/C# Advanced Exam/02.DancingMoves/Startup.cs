namespace _02.DancingMoves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var danceNumbers = ParseDanceNumberCommands();
            var directions = ParseDirectionCommands();

            var dancePointsSum = CalculateDancePointsSum(danceNumbers, directions);

            Console.WriteLine(dancePointsSum.ToString("0.0"));
        }

        private static IList<int> ParseDanceNumberCommands()
        {
            var danceNumbers = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToList();

            return danceNumbers;
        }

        private static IList<string> ParseDirectionCommands()
        {
            const string EndCommand = "stop";
            var directions = new List<string>();

            string command = Console.ReadLine();

            while (command != EndCommand)
            {
                directions.Add(command);
                command = Console.ReadLine();
            }

            return directions;
        }

        private static double CalculateDancePointsSum(IList<int> danceNumbers, IList<string> directions)
        {
            const string RightDirection = "right";
            double dancePointsSum = 0;
            int danceNumbersCellIndex = 0;

            for (int i = 0; i < directions.Count; i++)
            {
                string[] moveCommandParams = directions[i].Split(' ');

                int repeatCount = int.Parse(moveCommandParams[0]);
                bool shouldMoveRight = moveCommandParams[1] == RightDirection ? true : false;
                int step = int.Parse(moveCommandParams[2]);

                ExecuteDanceMove(repeatCount, danceNumbers, dancePointsSum, shouldMoveRight, step, danceNumbersCellIndex);
            }

            dancePointsSum = dancePointsSum / directions.Count;

            return dancePointsSum;
        }

        private static void ExecuteDanceMove(
            int repeatCount,
            IList<int> danceNumbers,
            double dancePointsSum,
            bool shouldMoveRight,
            int step,
            int danceNumbersCellIndex)
        {
            for (int j = 0; j < repeatCount; j++)
            {
                if (shouldMoveRight)
                {
                    danceNumbersCellIndex = (danceNumbersCellIndex + step) % danceNumbers.Count;
                    dancePointsSum += danceNumbers[danceNumbersCellIndex];
                }
                else
                {
                    danceNumbersCellIndex = ((danceNumbersCellIndex - step) % (danceNumbers.Count + danceNumbers.Count)) % danceNumbers.Count;
                    dancePointsSum += danceNumbers[danceNumbersCellIndex];
                }
            }
        }
    }
}
