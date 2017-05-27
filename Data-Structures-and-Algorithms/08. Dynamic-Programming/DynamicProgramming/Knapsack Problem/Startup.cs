using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_Problem
{
    class Startup
    {
        static void Main()
        {
            var productCount = int.Parse(Console.ReadLine());
            var weightLimit = int.Parse(Console.ReadLine());

            var products = ParseProducts(productCount);
        }

        private static List<List<string>> ParseProducts(int productCount)
        {
            var products = new List<List<string>>();

            for (int i = 0; i < productCount; i++)
            {
                products[i] = Console.ReadLine().Split('-').ToList();
            }

            return products;
        }

        private static void PickProducts(List<List<string>> products, int weightLimit)
        {

            while (weightLimit > 0)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i][)
                    {

                    }
                }
            }
        }
    }
}
