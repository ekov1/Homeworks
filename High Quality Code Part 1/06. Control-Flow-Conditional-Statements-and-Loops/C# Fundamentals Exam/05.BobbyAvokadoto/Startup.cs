namespace _05.BobbyAvokadoto
{
    using System;

    public class Startup
    {
        private const int BitNumber = 32;

        public static void Main()
        {
            uint bobbyHead = uint.Parse(Console.ReadLine());
            int totalCombNumber = int.Parse(Console.ReadLine());

            var bestComb = FindBestFittingComb(bobbyHead, totalCombNumber);

            Console.WriteLine(bestComb);
        }

        /// <summary>
        /// Loops through the combs and find the best one for Bobby's head
        /// </summary>
        /// <param name="bobbyHead">The number representing Bobby's head</param>
        /// <param name="totalCombNumber">The total number of given combs</param>
        /// <returns>Returns the number representing the best fitting comb for Bobby's head</returns>
        private static uint FindBestFittingComb(uint bobbyHead, int totalCombNumber)
        {
            int bestFitCount = 0;
            uint bestComb = 0;

            for (int i = 0; i < totalCombNumber; i++)
            {
                uint comb = uint.Parse(Console.ReadLine());
                var canUseComb = (bobbyHead & comb) == 0;

                if (!canUseComb)
                {
                    continue;
                }

                var fitCount = GetFittingSpotsCount(bobbyHead, comb);

                if (fitCount > bestFitCount)
                {
                    bestFitCount = fitCount;
                    bestComb = comb;
                }
            }

            return bestComb;
        }

        /// <summary>
        /// Gets the number of spots that fit for Bobby's head and the comb
        /// </summary>
        /// <param name="bobbyHead">The number representing Bobby's head</param>
        /// <param name="comb">The number representing the comb</param>
        /// <returns>Returns the number of passing spots</returns>
        private static int GetFittingSpotsCount(uint bobbyHead, uint comb)
        {
            var count = 0;

            for (int j = 0; j < BitNumber; j++)
            {
                int bitHead = GetBitAtPosition(bobbyHead, j);
                int bitComb = GetBitAtPosition(comb, j);

                var arePassingTogether = bitHead != bitComb;
                if (!arePassingTogether)
                {
                    continue;
                }

                count++;
            }

            return count;
        }

        /// <summary>
        /// Gets the bit at a given position in the number
        /// </summary>
        /// <param name="bitNumber">The given bit number</param>
        /// <param name="position">The index of the returned bit</param>
        /// <returns>Returns the bit at the position</returns>
        private static int GetBitAtPosition(uint bitNumber, int position)
        {
            var bit = (int)((bitNumber & (1 << position)) >> position);

            return bit;
        }
    }
}
