using System;
using System.Collections.Generic;

namespace _09.PrintSequenceMembers
{
    public class Startup
    {
        public static void Main()
        {
            var startNumber = int.Parse(Console.ReadLine());
            var sequenceLength = 50;
            var sequenceMembers = GetFirst50SequenceMembers(startNumber, sequenceLength);

            Console.WriteLine(string.Join(", ", sequenceMembers));
        }

        private static IList<int> GetFirst50SequenceMembers(int startNumber, int sequenceLength)
        {
            var queque = new Queue<int>();
            var sequenceMembers = new List<int>();

            queque.Enqueue(startNumber);

            for (int i = 0; i < sequenceLength; i++)
            {
                var firstNumber = queque.Dequeue();
                sequenceMembers.Add(firstNumber);

                queque.Enqueue(firstNumber + 1);
                queque.Enqueue((2 * firstNumber) + 1);
                queque.Enqueue(firstNumber + 2);
            }

            while (queque.Count > 0)
            {
                sequenceMembers.Add(queque.Dequeue());
            }

            return sequenceMembers;
        }
    }
}
