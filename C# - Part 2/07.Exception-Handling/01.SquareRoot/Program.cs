using System;
using System.Numerics;
namespace _01.SquareRoot
{
    class Program
    {
        static void Main()
        {
            try
            {
                double a = double.Parse(Console.ReadLine());
                if (a < 0)
                {
                    throw new FormatException();
                }
                double b = Math.Sqrt(a);
                Console.WriteLine(b.ToString("0.000"));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
