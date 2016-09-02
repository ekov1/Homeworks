namespace _01.Messages
{
    using System;
    using System.Numerics;

    public class Startup
    {
        static void Main()
        {
            string firstStringNumber = Console.ReadLine();
            char equasionSign = char.Parse(Console.ReadLine());
            string secondStringNumber = Console.ReadLine();

            string[] numeralSystemCharacters = new string[] { "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan" };

            firstStringNumber = ReplaceValues(firstStringNumber, numeralSystemCharacters);
            secondStringNumber = ReplaceValues(secondStringNumber, numeralSystemCharacters);

            var firstNumber = BigInteger.Parse(firstStringNumber);
            var secondNumber = BigInteger.Parse(secondStringNumber);
            BigInteger equasionResult = 0;

            if (equasionSign == '+')
            {
                equasionResult = firstNumber + secondNumber;
            }
            else if (equasionSign == '-')
            {
                equasionResult = firstNumber - secondNumber;
            }

            string equasionResultString = DecimalToBase(equasionResult);

            equasionResultString = ReplaceValues(equasionResultString, numeralSystemCharacters);

            Console.WriteLine(equasionResultString);

        }

        static string ReplaceValues(string number, string[] chars)
        {
            var isNumber = char.IsDigit(number[0]);

            if (!isNumber)
            {
                for (int i = 0; i < 10; i++)
                {
                    number = number.Replace(chars[i], i.ToString());
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    number = number.Replace(i.ToString(), chars[i]);
                }
            }
            return number;
        }

        static string DecimalToBase(BigInteger decimalNumber)
        {
            string convertedStringValue = string.Empty;
            do
            {
                BigInteger digit = decimalNumber % 10;

                convertedStringValue = (char)(digit + '0') + convertedStringValue;
                decimalNumber = decimalNumber / 10;

            } while (decimalNumber > 0);

            convertedStringValue = convertedStringValue.TrimStart('0');
            return convertedStringValue;
        }
    }
}