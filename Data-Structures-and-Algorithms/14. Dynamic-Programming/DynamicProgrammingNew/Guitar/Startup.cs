using System;
using System.Collections.Generic;
using System.Linq;

namespace Guitar
{
    public class Startup
    {
        public static void Main()
        {
            var changesCount = int.Parse(Console.ReadLine());
            var changes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var initialVolume = int.Parse(Console.ReadLine());
            var maxVolume = int.Parse(Console.ReadLine());

            //var result = FindMaxVolumeRecursive(initialVolume, changes, 0, maxVolume);
            var result = FindMaxVolumeDynamic(changes, maxVolume, initialVolume);

            Console.WriteLine(result);
        }

        private static int FindMaxVolumeDynamic(int[] changes, int maxVolume, int initialVolume)
        {
            var partials = new bool[changes.Length + 1, maxVolume + 1];
            var result = -1;

            partials[0, initialVolume] = true;

            for (int i = 1; i < partials.GetLength(0); i++)
            {
                for (int j = 0; j < partials.GetLength(1); j++)
                {
                    if (partials[i - 1, j])
                    {
                        if (j + changes[i - 1] < partials.GetLength(1))
                        {
                            partials[i, j + changes[i - 1]] = true;
                        }

                        if (j - changes[i - 1] >= 0)
                        {
                            partials[i, j - changes[i - 1]] = true;
                        }
                    }
                }
            }

            for (int i = partials.GetLength(1) - 1; i >= 0; i--)
            {
                if (partials[partials.GetLength(0) - 1, i])
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        private static int FindMaxVolumeRecursive(int currentVolume, int[] volumes, int songIndex, int maxVolume)
        {
            if (currentVolume < 0 || currentVolume > maxVolume)
            {
                return -1;
            }

            if (songIndex == volumes.Length)
            {
                if (currentVolume <= maxVolume && currentVolume >= 0)
                {
                    return currentVolume;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return Math.Max(FindMaxVolumeRecursive(currentVolume + volumes[songIndex], volumes, songIndex + 1, maxVolume),
                    FindMaxVolumeRecursive(currentVolume - volumes[songIndex], volumes, songIndex + 1, maxVolume));
            }
        }
    }
}
