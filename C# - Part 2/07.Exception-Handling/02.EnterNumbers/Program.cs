using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main()
        {
            long[] arr = new long[10];

            try
            {
               
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = long.Parse(Console.ReadLine());
                }
                bool readNumber = ReadNumber(arr);
                if (readNumber == false)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    Console.WriteLine(DisplayElements(arr));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Exception");

            }
            catch (ArgumentOutOfRangeException)
            {

                Console.WriteLine("Exception");
            }
            
            
        }

        static string DisplayElements(long[] arr)
        {
            string start = "1 < ";
            string end = " < 100";
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                builder.Append(arr[i]);
                if (i == arr.Length - 1)
                {
                    break;
                }
                builder.Append(" < ");
                
            }
            builder.Insert(0, start);
            builder.Append(end);

            return builder.ToString();
        }

        static bool ReadNumber(long[] arr)
        {

            bool accending = true;
            if (arr[0] <= 1 || arr[arr.Length - 1] >= 100)
            {
                accending = false;
                return accending;
            }
            
            long first = arr[0];
            
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] <= first)
                {
                    accending = false;
                    break;
                }
                
                first = arr[i];
            }
            return accending;
        }
    }
}
