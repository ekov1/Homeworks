using System;

namespace _12.IndexOfLetters
{
    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            char[] wordChArr = word.ToCharArray();
            char[] alphabet = new char[26];
            int k = 0;
            for (int i = 97; i <= 122; i++)
            {
                alphabet[k] = (char)i;
                k++;
            }

            for (int j = 0; j < word.Length; j++)
            {
                int index = Array.IndexOf(alphabet, wordChArr[j]);
                Console.WriteLine(index);
            }
        }
    }
}
