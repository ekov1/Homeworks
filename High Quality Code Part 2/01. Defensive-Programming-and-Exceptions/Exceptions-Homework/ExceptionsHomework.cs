using System;
using System.Collections.Generic;
using Exceptions_Homework.Utils;

public class ExceptionsHomework
{
    public static void Main()
    {
        StringOperationsExample();

        MathOperationsExample();

        ExamsExample();
    }

    private static void StringOperationsExample()
    {
        var subString = MathOperations.GetSubsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(subString);

        var numbersArray = new int[] { -1, 3, 2, 1 };

        var subArray = MathOperations.GetSubsequence(numbersArray, 0, 2);
        Console.WriteLine(string.Join(" ", subArray));

        var subArrayWithInitialArrayLength = MathOperations.GetSubsequence(numbersArray, 0, numbersArray.Length);
        Console.WriteLine(string.Join(" ", subArrayWithInitialArrayLength));

        var emptyArray = MathOperations.GetSubsequence(numbersArray, 0, 0);
        Console.WriteLine(string.Join(" ", emptyArray));

        Console.WriteLine(GetExtractedStringEndings());
    }

    private static string GetExtractedStringEndings()
    {
        var result = new List<string>();
        var extractStrings = new Dictionary<string, int>()
        {
            { "I love C#", 2 },
            { "Nakov", 4 },
            { "beer", 4 },
            { "Hi", 100 }
        };

        foreach (var str in extractStrings)
        {
            try
            {
                result.Add(StringOperations.ExtractEnding(str.Key, str.Value));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Cannot extract ending with length {0} from '{1}'!", str.Value, str.Key);
            }
        }

        var returnString = string.Join(" ", result);

        return returnString;
    }

    private static void MathOperationsExample()
    {
        // I don't think that for checking are numbers prime we should throw an exception
        var numbers = new List<int>();

        foreach (var number in numbers)
        {
            var isPrime = MathOperations.IsPrime(number);

            if (isPrime)
            {
                Console.WriteLine("{0} is prime!", number);
            }
            else
            {
                Console.WriteLine("{0} is NOT prime!", number);
            }
        }
    }

    private static void ExamsExample()
    {
        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}