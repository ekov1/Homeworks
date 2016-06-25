using System;

namespace _02.CorrectBrackets
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ')')
                {
                    counter--;
                }
                if (a[i] == '(')
                {
                    counter++;
                    
                }
                
            }

            if (counter != 0)
            {
                Console.WriteLine("Incorrect");
            }
            else if (counter == 0)
            {
                Console.WriteLine("Correct");
            }
        }
    }
}
