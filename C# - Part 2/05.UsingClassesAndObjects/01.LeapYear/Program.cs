using System;

namespace _01.LeapYear
{
    class Program
    {
        static void Main()
        {
            int year = int.Parse(Console.ReadLine());
            LeapOrCommon(year);
        }

        static void LeapOrCommon(int year)
        {
            bool isLeap = false;
            if (year % 4 == 0)
            {
                isLeap = true;
                if (year % 100 == 0)
                {
                    isLeap = false;
                    if (year % 400 == 0)
                    {
                        isLeap = true;
                    }
                }
            }

            string result = isLeap == true ? "Leap" : "Common";
            Console.WriteLine(result);
        }
    }
}
