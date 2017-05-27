using System;
using System.Linq;
using System.Numerics;

namespace _01.BinaryPasswords
{
    public class Startup
    {
        public static void Main()
        {
            var passwordPattern = Console.ReadLine().ToArray();
            var unknownCharacters = passwordPattern.Where(x => x == '*').Count();

            //// Bit shifting for powers of 2 doesn't work correct with big numbers ( Example: string length => 60 )
            BigInteger combinationCount = BigInteger.Pow(2, unknownCharacters);
            Console.WriteLine(combinationCount);
        }
    }
}
