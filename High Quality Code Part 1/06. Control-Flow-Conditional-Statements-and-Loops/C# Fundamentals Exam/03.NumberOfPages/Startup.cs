namespace _03.NumberOfPages
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
            int totalNumberingDigits = int.Parse(Console.ReadLine());
            int pageCount = 0;
            int sumOfDigits = 0;

            while (totalNumberingDigits != sumOfDigits)
            {
                pageCount++;

                sumOfDigits += pageCount.ToString().Length;
            }
            Console.WriteLine(pageCount);
        }
    }
}
