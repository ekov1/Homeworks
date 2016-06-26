namespace _03.RangeExceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            try
            {
                string[] names = new string[101];
                if (names.Length < 1 || names.Length > 100)
                {
                    throw new InvalidRangeException<int>("Invalid range/Length cannot be less than 1 or more than 100!", 1, 100);
                }

            }
            catch (InvalidRangeException<int> exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                DateTime dateAndTime = new DateTime(1597, 3, 23);
                if (dateAndTime < new DateTime(1980, 1, 1) || dateAndTime > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>("\nInvalid range/Year cannot be before 1980 or after 2013!", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }
            }
            catch (InvalidRangeException<DateTime> exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
