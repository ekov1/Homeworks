using System;
using System.Linq;

namespace SuperMarioWorkshop
{
    public class Startup
    {
        // generating cell formula: (Ci * A + B) % M
        public static void Main()
        {
            var nk = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var fabm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = nk[0];
            var k = nk[1];

            var f = fabm[0];
            var a = fabm[1];
            var b = fabm[2];
            var m = fabm[3];

            var prices = new long[n + 1];
            prices[0] = f;

            for (int i = 1; i < n; i++)
            {
                prices[i] = (prices[i - 1] * a + b) % m;
            }

            for (int i = k; i <= n; i++)
            {
                var minResult = long.MaxValue;

                for (int j = i - k; j < i; j++)
                {
                    var currentElement = prices[j];

                    if (currentElement < minResult)
                    {
                        minResult = currentElement;
                    }
                }

                prices[i] += minResult;
            }

            Console.WriteLine(prices[n]);
        }
    }
}
