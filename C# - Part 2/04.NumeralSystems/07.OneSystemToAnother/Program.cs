using System;

namespace _07.OneSystemToAnother
{
    class Program
    {
        static void Main()
        {
            int firstSystem = int.Parse(Console.ReadLine());
            string number = Console.ReadLine();
            int secondSystem = int.Parse(Console.ReadLine());

            long result = BaseToDec(number, firstSystem);
            Console.WriteLine(DecToBase(result, secondSystem));
        }

        static long Power(long number, long power)
        {
            long result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= number;
            }
            
            return result;
        }

        static long BaseToDec(string number, int numSystem)
        {
            int digit = 0;
            long result = 0;
            number = number.ToUpper();

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] >= '0' && number[i] <= '9')
                {
                    digit = number[i] - '0';
                }
                else if (number[i] >= 'A' && number[i] <= 'F') //If base greater than 16 leave ELSE without condition
                {
                    digit = number[i] - 'A' + 10;  
                }

                result += digit * (Power(numSystem, number.Length - i - 1));
            }

            return result;
        }

        static string DecToBase(long dec, int numSystem)
        {
            string result = "";
            do
            {
                long digit = dec % numSystem;

                if (digit >= 0 && digit <= 9)
                {
                    result = (char)(digit + '0') + result;
                }
                else if (digit >= 10 && digit <= 15)
                {
                    result = (char)(digit - 10 + 'A') + result;
                }

                dec = dec / numSystem;

            } while (dec != 0);
            result = result.TrimStart('0');
            return result;
        }
    }
}
