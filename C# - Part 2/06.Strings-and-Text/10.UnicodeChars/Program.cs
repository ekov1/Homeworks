using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;
        char[] arrInput = Console.ReadLine().ToCharArray();
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < arrInput.Length; i++)
        {
            if (arrInput[i] == ' ')
            {
                builder.Append(' ');
            }
            string hex = Convert.ToByte(arrInput[i]).ToString("x2").PadLeft(4, '0');
            builder.Append("\\u" + hex);
        }
        string result = builder.ToString();
        Console.WriteLine(result.ToUpper());
    }
}