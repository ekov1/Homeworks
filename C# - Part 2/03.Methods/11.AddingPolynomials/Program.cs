using System;
using System.Linq;

namespace _11.AddingPolynomials
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] firstNumber = new string[n];
            string num = Console.ReadLine();
            firstNumber = num.Split(' ');

            string[] secondNumber = new string[n];
            string number = Console.ReadLine();
            secondNumber = number.Split(' ');

            string res = AddPolynomials(firstNumber, secondNumber);
            Console.WriteLine(res);
        }

        static string AddPolynomials(string[] firstNumber, string[] secondNumber)
        {
            int[] sumOfNums = new int[firstNumber.Length];
            for (int i = 0; i < firstNumber.Length; i++)
            {
                sumOfNums[i] = int.Parse(firstNumber[i]) + int.Parse(secondNumber[i]);
            }
            string result = "";
            for (int i = 0; i < sumOfNums.Length; i++)
            {
                result += sumOfNums[i] + " ";
            }
            return result;
        }
    }
}
